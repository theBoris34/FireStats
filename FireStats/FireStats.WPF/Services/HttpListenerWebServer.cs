using FireStats.Web;
using FireStats.WPF.Services.Interfaces;
using System;
using System.IO;

namespace FireStats.WPF.Services
{
    internal class HttpListenerWebServer : IWebServerService
    {

        private WebServer _Server = new WebServer(8080);

        public bool Enable { get => _Server.Enabled ; set => _Server.Enabled = value; }

        public void Start() => _Server.Start();

        public void Stop() => _Server.Stop();

        public HttpListenerWebServer()
        {
            _Server.RequestReceived += OnRequestResived;
        }

        private void OnRequestResived(object sender, RequestReceiverEventArgs e)
        {
            using var writer = new StreamWriter(e.Context.Response.OutputStream);
            writer.WriteLine("Firestats Application!");
        }
    }
}
