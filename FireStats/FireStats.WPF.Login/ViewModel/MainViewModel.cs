using FireStats.BL.Controller;
using FireStats.WPF.Login;
using FireStats.WPF.Login.Pages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FireStats.BL.ViewModel
{
    class MainViewModel : ViewModel
    {
        private Page EnterFirePage;
        private Page ShowFirePage;

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }       


        public MainViewModel(UserController UserController)
        {
            EnterFirePage = new EnterFirePage(UserController);
            ShowFirePage = new ShowFirePage(UserController);
            CurrentPage = ShowFirePage;
        }

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
