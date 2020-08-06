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
using System.Windows.Shapes;

namespace FireStats.WPF.Login
{
    /// <summary>
    /// Логика взаимодействия для WindowFireStats.xaml
    /// </summary>
    public partial class WindowFireStats : Window
    {
        public UserController UserController { get; set; }
        //Console.WriteLine("Что сделать?");
        //Console.WriteLine("F - внести пожар.");
        //Console.WriteLine("E - внести ЧС.");
        // Console.WriteLine("V - просмотреть список пожаров.");
        // Console.WriteLine("B - просмотреть список ЧС.");
        // Console.WriteLine("H - просмотреть справку.");
        // Console.WriteLine("D - изменить дату.");
        //Console.WriteLine("P - изменить тип пользователя.");
        // Console.WriteLine("Q - изменить пользователя.");
        public WindowFireStats()
        {
            InitializeComponent();
        }
        public WindowFireStats(string name)
        {
            UserController = new UserController(name);
            InitializeComponent();
        }
        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            DataGridResault.ItemsSource = UserController.CurrentUser.Fires;

        }
    }
}
