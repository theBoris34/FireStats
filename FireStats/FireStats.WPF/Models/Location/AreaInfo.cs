using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FireStats.WPF.Models.Location
{
    /// <summary>
    /// Информация об области.
    /// </summary>
    class AreaInfo : PlaceInfo
    {
        private Point? _Location;

        /// <summary>
        /// Положение области. Среднее значение по всем районам.
        /// </summary>
        public override Point Location
        {
            get
            {
                if (_Location != null)
                    return (Point)_Location;

                if (Districts is null) return default;

                var average_x = Districts.Average(p => p.Location.X);
                var average_y = Districts.Average(p => p.Location.Y);

                return (Point)(_Location = new Point(average_x, average_y));
            }
            set => _Location = value;
        }

        public IEnumerable<PlaceInfo> Districts { get; set; }

        private IEnumerable<ConfirmedCount> _Counts;

        public override IEnumerable<ConfirmedCount> Counts
        {
            get
            {
                if (_Counts != null) return _Counts;

                var points_count = Districts.FirstOrDefault()?.Counts?.Count() ?? 0;
                if (points_count == 0) return Enumerable.Empty<ConfirmedCount>();

                var area_points = Districts.Select(p => p.Counts.ToArray()).ToArray();

                var points = new ConfirmedCount[points_count];
                foreach (var area in area_points)
                    for (var i = 0; i < points_count; i++)
                    {
                        if (points[i].Date == default)
                            points[i] = area[i];
                        else
                            points[i].Count += area[i].Count;
                    }

                return _Counts = points;
            }
            set => _Counts = value;
        }
    }
}
