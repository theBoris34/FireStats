using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.ViewModels.Base;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    class WebServerViewModel : ViewModel
    {

        private readonly IWebServerService _Server;
        public bool Enabled 
        { 
            get => _Server.Enable; 
            set 
            {
                _Server.Enable = value;
                OnPropertyChanged();
            } 
        }

        #region StartCommand
        private ICommand _StartCommand;

        public ICommand StartCommand => _StartCommand ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private bool CanStartCommandExecute(object p) => !Enabled;

        private void OnStartCommandExecuted(object p)
        {
            _Server.Start();
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion

        #region StopCommand
        private ICommand _StopCommand;

        public ICommand StopCommand => _StopCommand ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);

        private bool CanStopCommandExecute(object p) => Enabled;

        private void OnStopCommandExecuted(object p)
        {
            _Server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion
        public WebServerViewModel():this(null) { }

        public WebServerViewModel(IWebServerService Server)
        {
            _Server = new HttpListenerWebServer();//???из-за создания новых страниц нельзя создать еще один сервер.
        }
    }
}
