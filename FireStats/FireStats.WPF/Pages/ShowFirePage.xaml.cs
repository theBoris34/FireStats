using FireStats.BL.Controller;
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

namespace FireStats.WPF.Login.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowFirePage.xaml
    /// </summary>
    public partial class ShowFirePage : Page
    {
        public ShowFirePage(UserController UserController)
        {
            InitializeComponent();
            DataGridResault.ItemsSource = UserController.CurrentUser.Fires;
            DataContext = new ViewModel.ShowFiresPageModel();
        }
    }
}
 