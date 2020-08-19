using FireStats.WPF.Infrastructure.Commands.Base;
using FireStats.WPF.Pages;
using FireStats.WPF.ViewModels;
using FireStats.WPF.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FireStats.WPF.Infrastructure.Commands
{
    class EmployeeListCommand : Command
    {
        private WindowFireStats _Window;
        private WindowFireStatsViewModel _Window1;
        private EmployeeListPage _Page;
        public override bool CanExecute(object parameter) => _Page == null;

        public override void Execute(object parameter)
        {
           var page = new EmployeeListPage();
           _Page = page;
        }
    }

}
