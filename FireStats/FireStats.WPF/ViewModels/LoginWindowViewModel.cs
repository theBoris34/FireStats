using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    class LoginWindowViewModel : ViewModel
    {
        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            if (MessageBox.Show("Закрыть приложение?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString() == "Yes")
                Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion
      

        #endregion

        public LoginWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
           
            #endregion
        }
    }
}
