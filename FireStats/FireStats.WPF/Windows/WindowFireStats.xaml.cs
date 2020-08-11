using FireStats.BL.Controller;
using System.Windows;
using System.Windows.Input;

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
           // DataContext = new MainViewModel(UserController);
            LoginName.Text = name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataGridResault.ItemsSource = UserController.CurrentUser.Fires;
        }

        /// <summary>
        /// Закрытие приложение на форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {                         
              this.Close();
        }

        /// <summary>
        /// Свернуть окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Передвижение окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DataGridResault.ItemsSource = UserController.CurrentUser.Fires;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
//DataGridResault.ItemsSource = UserController.CurrentUser.Emergencies;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           // DataGridResault.ItemsSource = UserController.Users;
        }

        /// <summary>
        /// Кнопка открытия меню пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {

            if (UserGrid.Visibility == Visibility.Hidden)
                UserGrid.Visibility = Visibility.Visible;
            else
                UserGrid.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Смена пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        /// <summary>
        /// Выход из приложения через меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString() == "Yes")
                this.Close();
        }
    }
}
