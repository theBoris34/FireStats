using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;
using FireStats.WPF.Infrastructure.Commands;
using System.Windows;
using FireStats.WPF.ViewModels.Base;
using FireStats.WPF.Pages;
using FireStats.WPF;

namespace FireStats.WPF.ViewModels
{
    internal class WindowFireStatsViewModel : ViewModel
    {
        private Page _CurrentPage;
        /// <summary>
        /// Текущая страница.
        /// </summary>
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                Set(ref _CurrentPage, value);
            }
        }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private string _CurrentUser = "Пользователь";
        public string CurrentUser 
        { 
            get { return _CurrentUser; }
            set
            {
                Set(ref _CurrentUser, value);
            }
        }

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


        #region EnterFirePageShowCommand
        public ICommand EnterFirePageShowCommand { get; }

        private void OnEnterFirePageShowCommandExecuted(object p)
        {
            CurrentPage = new EnterFirePage();
        }
        private bool CanEnterFirePageShowCommandExecute(object p) => true;
        #endregion


        #region ShowFirePageShowCommand

        public ICommand ShowFirePageShowCommand { get; }

        private void OnShowFirePageShowCommandExecuted(object p)
        {
            CurrentPage = new ShowFirePage();
        }
        private bool CanShowFirePageShowCommandExecute(object p) => true;
        #endregion

        #region ShowEmergancyPageShowCommand

        public ICommand ShowEmergancyPageShowCommand { get; }

        private void OnShowEmergancyPageShowCommandExecuted(object p)
        {
            CurrentPage = new ShowEmergancyPage();
        }
        private bool CanShowEmergancyPageShowCommandExecute(object p) => true;
        #endregion



        #region EnterEmergancyPageShowCommand

        public ICommand EnterEmergancyPageShowCommand { get; }

        private void OnEnterEmergancyPageShowCommandExecuted(object p)
        {
            CurrentPage = new EnterEmergancyPage();
        }
        private bool CanEnterEmergancyPageShowCommandExecute(object p) => true;
        #endregion
        //ChangeUser


        #region UserListPageShowCommand

        public ICommand UserListPageShowCommand { get; }

        private void OnUserListPageShowCommandExecuted(object p)
        {
            CurrentPage = new UserListPage();
        }
        private bool CanUserListPageShowCommandExecute(object p) => true;
        #endregion


        #region ChangeUserCommand
        /// <summary>
        /// Перезагрузка приложения.
        /// </summary>
        public ICommand ChangeUserCommand { get; }

      
        private void OnChangeUserCommandExecuted(object p)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private bool CanChangeUserCommandExecute(object p) => true;
        #endregion

        #endregion
        public WindowFireStatsViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            EnterFirePageShowCommand = new LambdaCommand(OnEnterFirePageShowCommandExecuted, CanEnterFirePageShowCommandExecute);
            ShowFirePageShowCommand = new LambdaCommand(OnShowFirePageShowCommandExecuted, CanShowFirePageShowCommandExecute);
            ShowEmergancyPageShowCommand = new LambdaCommand(OnShowEmergancyPageShowCommandExecuted, CanShowEmergancyPageShowCommandExecute);
            EnterEmergancyPageShowCommand = new LambdaCommand(OnEnterEmergancyPageShowCommandExecuted, CanEnterEmergancyPageShowCommandExecute);
            UserListPageShowCommand = new LambdaCommand(OnUserListPageShowCommandExecuted, CanUserListPageShowCommandExecute);
            ChangeUserCommand = new LambdaCommand(OnChangeUserCommandExecuted, CanChangeUserCommandExecute);
            #endregion
        }
        

    }
}
