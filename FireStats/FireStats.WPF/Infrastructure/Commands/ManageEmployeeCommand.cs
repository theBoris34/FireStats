using FireStats.WPF.Infrastructure.Commands.Base;
using FireStats.WPF.Windows;
using System;
using System.Windows;

namespace FireStats.WPF.Infrastructure.Commands
{
    class ManageEmployeeCommand : Command
    {
        private EmployeesManagmentWindow _Windows;
        public override bool CanExecute(object parameter) => _Windows == null;
        
        public override void Execute(object parameter)
        {
            var windows = new EmployeesManagmentWindow
            {
                Owner = Application.Current.MainWindow
            };
            _Windows = windows;
            windows.Closed += OnWindowClosed;

            windows.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window) sender).Closed -= OnWindowClosed;
            _Windows = null;
        }


    }
}
