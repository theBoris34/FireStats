using System;
using System.Net;
using System.Threading.Tasks;

namespace FireStats.Web
{
    public class RequestReceiverEventArgs : EventArgs 
    { 
        public HttpListenerContext Context { get; }

        public RequestReceiverEventArgs(HttpListenerContext context) => Context = context;
    }

    public class WebServer
    {

        public event EventHandler<RequestReceiverEventArgs> RequestReceived;
        //private TcpListener _Listener = new TcpListener(new IPEndPoint(IPAddress.Any,8080));
        private HttpListener _Listener;
        private readonly int _Port;
        private bool _Enabled;
        private readonly object _SyncRoot = new object();
        public int Port => _Port;

        public bool Enabled { get => _Enabled; set { if (value) Start(); else Stop(); } }

        public WebServer(int Port) => _Port = Port;

        public void Start() 
        {
            if (_Enabled) return;
            lock(_SyncRoot)//блокировка критической секции
            {
                if (_Enabled) return;
                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{_Port}/"); //регистрация порта !!НЕОБХОДИМО РАЗРЕШИТЬ ИСПОЛЬЗОВАНЕ ПРЕФИКСА!!
                _Listener.Prefixes.Add($"http://+:{_Port}/"); // вот это в CMD от админа! : netsh http add urlacl url=http://*:8080/ user=Akinf
                _Enabled = true;
            }
            ListenAsync();
        }

        public void Stop()
        {
            if (!_Enabled) return;
            lock (_SyncRoot)//блокировка критической секции
            {
                if (!_Enabled) return;

                _Listener = null;
                _Enabled = false;
            }
        }

        private async void ListenAsync()
        {
            var listner = _Listener;

            listner.Start();

            HttpListenerContext context = null;

            while (_Enabled)
            {
                var get_context_task = listner.GetContextAsync();
                if(context!=null)
                    ProcessRequestAsync(context);
                context = await get_context_task.ConfigureAwait(false);
            }


            listner.Stop();
        }

        private async void ProcessRequestAsync(HttpListenerContext context)
        {
            await Task.Run(() => RequestReceived?.Invoke(this, new RequestReceiverEventArgs(context)));
           
        }

    }
}
