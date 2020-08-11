using FireStats.BL.Controller;
using FireStats.WPF.Login;
using FireStats.WPF.Login.Pages;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;
using FireStats.WPF.Login.ViewModel.Base;

namespace FireStats.WPF.ViewModels
{
    internal class WindowFireStatsViewModel : ViewModel
    {
        private Page EnterFirePage;
        private Page ShowFirePage;

        private Page _currentPage;
        /// <summary>
        /// Текущая страница.
        /// </summary>
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                Set(ref _currentPage, value);
            }
        }

        private string _currentUser = "Пользователь";
        public string CurrentUser 
        { 
            get { return _currentUser; }
            set
            {
                Set(ref _currentUser, value);
            }
        }


        //public MainViewModel(UserController UserController)
        //{
        //    EnterFirePage = new EnterFirePage(UserController);
        //    ShowFirePage = new ShowFirePage(UserController);
        //    CurrentPage = ShowFirePage;
        //}

        public ICommand EnterFireButton_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = EnterFirePage);
            }
        }

        public ICommand ShowFirePage_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = ShowFirePage);
            }
        }        
    }
}
