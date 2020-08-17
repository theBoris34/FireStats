using FireStats.WPF.Models;
using FireStats.WPF.Models.Location;
using FireStats.WPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FireStats.WPF.Services
{
    
    internal class DataService : IDataService
    {
        private const string _DataSourceAdress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        public DataService()
        {

        }
        /// <summary>
        /// Получение потока данных с сайта.
        /// </summary>
        /// <returns></returns>
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_DataSourceAdress, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Перечисление строк.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetDataLines()
        {
            //контекст синхронизации 
            using var data_stream = (SynchronizationContext.Current is null ? GetDataStream() : Task.Run(GetDataStream)).Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Korea,", "Korea -").Replace("Bonaire,", "Bonaire -");
            }
        }

        /// <summary>
        /// Получение временных отметок для которых установленны данные.
        /// </summary>
        /// <returns></returns>
        private static DateTime[] GetDates() => GetDataLines()
           .First()
           .Split(',')
           .Skip(4)
           .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
           .ToArray();

        /// <summary>
        /// Извлечение информации по каждой стране.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<(string District, string Area, (double Lat, double Lon) Place, int[] Counts)> GetAreaData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var district = row[0].Trim();
                var area_name = row[1].Trim(' ', '"');
                var latitude = double.Parse(row[2]);
                var longitude = double.Parse(row[3]);
                var counts = row.Skip(4).Select(int.Parse).ToArray();

               

                yield return (district, area_name, (latitude,longitude), counts);
            }

        }


        public IEnumerable<AreaInfo> GetData()
        {

            var dates = GetDates();

            var data = GetAreaData().GroupBy(n => n.Area);

            foreach (var area_info in data)
            {
                var area = new AreaInfo
                {
                    Name = area_info.Key,
                    Districts = area_info.Select(a => new PlaceInfo
                    {
                        Name = a.District,
                        Location = new Point(a.Place.Lat, a.Place.Lon),
                        Counts = dates.Zip(a.Counts, (date, count) => new ConfirmedCount { Date = date, Count = count })
                    })
                };
                yield return area;
            }

        }
    }
}
