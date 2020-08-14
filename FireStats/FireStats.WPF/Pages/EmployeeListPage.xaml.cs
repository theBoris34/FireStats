using FireStats.WPF.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime;
using System.Windows.Media.Media3D;

namespace FireStats.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        public EmployeeListPage()
        {
            InitializeComponent();
        }
      

        private void DivisionCollectionFilter(object sender, FilterEventArgs e)
        {
            var filter_text = DivisionFilter.Text;
            if (!(e.Item is Division division)) return;
            if (division.Name == null) return;
            if (filter_text.Length == 0) return;

            if (division.Name.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (division.Note != null && division.Note.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;

            e.Accepted = false;
        }

        private void OnDivisionsFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var text_box = (TextBox)sender;
            var collection = (CollectionViewSource)text_box.FindResource("DivisionsCollection");
            collection.View.Refresh();
        }
    }
}
