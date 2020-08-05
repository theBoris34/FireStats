﻿using FireStats.BL.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace FireStats.WPF.Login
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LeftGrid.Visibility == Visibility.Hidden)
                LeftGrid.Visibility = Visibility.Visible;
            else
                LeftGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RightGrid.Visibility == Visibility.Hidden)
                RightGrid.Visibility = Visibility.Visible;
            else
                RightGrid.Visibility = Visibility.Hidden;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tb2.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else WaterMark.Visibility = Visibility.Visible;
        }

        //клик по кнопке Авторизоваться
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = tb1.Text;
            String pasUser = tb2.Password;

            DataBase DataBase = new DataBase();

            DataTable Table = new DataTable();

            MySqlDataAdapter Adapter = new MySqlDataAdapter();

            MySqlCommand Command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", DataBase.GetConnection());

            Command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            Command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pasUser;

            Adapter.SelectCommand = Command;
            Adapter.Fill(Table);

            if (Table.Rows.Count > 0)
                MessageBox.Show("Авторизован");
            else
                MessageBox.Show("Не авторизован");



            /*Console.Title = $"FIRESTAT. Изменение пользователя.";
            Console.Clear();
            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Такого пользователя не существует. Зарегистрируйтесь.");
                Console.Title = $"FIRESTAT. Изменение пользователя. Регистрация нового пользователя.";
                Console.Write("Введите тип объекта(0-НЦУКС, 1-ЦУКС по ФО, 2-ЦУКС, 3-ЕДДС, 4-ПСЧ): ");
                var userType = int.Parse(Console.ReadLine());//проверка
                Console.Write("Введите адрес объекта: ");
                var adress = Console.ReadLine();//проверка                
                userController.SetNewUserData(userType, adress, personnel, fireTruck);
            }
            Console.Title = $"FIRESTAT. Изменение пользователя.";
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
            return userController;*/
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            CheckInWindow CheckIn = new CheckInWindow();
            CheckIn.Show();
        }
    }
}
