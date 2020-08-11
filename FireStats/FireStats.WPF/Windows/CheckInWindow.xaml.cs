using FireStats.BL.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace FireStats.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для CheckInWindow.xaml
    /// </summary>
    public partial class CheckInWindow : Window
    {
        public CheckInWindow()
        {
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

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tb2.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else WaterMark.Visibility = Visibility.Visible;
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            //ПРОВЕРКА
            if (string.IsNullOrWhiteSpace(tb1.Text))
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }

            if (!UserIsNow())
                return;

            DataBase DataBase = new DataBase();

            MySqlCommand Command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `department`, `adress`, `personnel`, `fireTruck`) VALUES (@login, @pass, @nameDepart, @adress, @ls, @ft)", DataBase.GetConnection());
            Command.Parameters.Add("@login",MySqlDbType.VarChar).Value = tb1.Text.ToLower();
            Command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = tb2.Password;
            Command.Parameters.Add("@nameDepart", MySqlDbType.VarChar).Value = tb3.Text;
            Command.Parameters.Add("@adress", MySqlDbType.VarChar).Value = tb4.Text;
            Command.Parameters.Add("@ls", MySqlDbType.Int32).Value = tb5.Text;
            Command.Parameters.Add("@ft", MySqlDbType.Int32).Value = tb6.Text;

            DataBase.OpenConnection();
            if (Command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
                this.Close();
                LoginWindow mainWindow = new LoginWindow();
                mainWindow.Show();
            }

            else
                MessageBox.Show("Аккаунт не создан");

            DataBase.CloseConnection();
        }

        public Boolean UserIsNow()
        {


            DataBase DataBase = new DataBase();

            DataTable Table = new DataTable();

            MySqlDataAdapter Adapter = new MySqlDataAdapter();

            MySqlCommand Command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", DataBase.GetConnection());

            Command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = tb1.Text.ToLower();

            Adapter.SelectCommand = Command;
            Adapter.Fill(Table);

            if (Table.Rows.Count > 0)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
