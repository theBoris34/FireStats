using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FireStats.WPF.Services
{
    class WindowsUserDialogService : IUserDialogService
    {
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch(item)
            {
                case Employee employee:
                    return EditEmployee(employee);
                default: throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");

            }
        }


        public bool Confirm(string Message, string Caption, bool Exclamation = false)
        {
            return MessageBox.Show(Message, Caption, MessageBoxButton.YesNo, Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);
       

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);


        private bool EditEmployee(Employee employee)
        {
            var dlg = new EmployeeEditorWindows
            {
                FirstName = employee.Name,
                SurName = employee.Surname,
                Patronymic = employee.Patronymic,
                Birthday = employee.Birthday,
                Rank = employee.Rank,
                Position = employee.Position,
                Note = employee.Note
            };

            if (dlg.ShowDialog() != true) return false;

            employee.Name = dlg.FirstName;
            employee.Surname = dlg.SurName;
            employee.Patronymic = dlg.Patronymic;
            employee.Birthday = dlg.Birthday;
            employee.Rank = dlg.Rank;
            employee.Position = dlg.Position;
            employee.Note = dlg.Note;

            return true;
        }
    }
}
