using FireStats.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireStats.Web;
using System.IO;

namespace COVID
{
    internal class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);

            server.RequestReceived += OnRequestRecrived;
            server.Start();
            Console.WriteLine("Сервер запущен!");
            Console.ReadLine();

        }

        private static void OnRequestRecrived(object sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;

            Console.WriteLine("Connection{0}", context.Request.UserHostAddress);

            using var writer = new StreamWriter(context.Response.OutputStream);
            writer.WriteLine("Hello from Test Web Server!");
        }
    }
}
