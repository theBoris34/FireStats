using FireStats.BL.Controller;
using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FireStats.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class EnterFirePage : Page
    {

        public EnterFirePage()
        {
            InitializeComponent();
        }
        public UserController UserController { get; set; }
        public EnterFirePage(UserController userController)
        {
            InitializeComponent();
            UserController = userController;
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            var fire = EnterFire();
            UserController.Add(fire);
            MessageBox.Show(fire.ToString());
        }

        private Fire EnterFire()
        {
            WorkTime workTime = new WorkTime();
            List<User> fieldUnits = new List<User>
            {
                new User("pch1"),
                new User("pch2")
            };
            var adress = tb1.Text;
            var applicant = tb2.Text;
            var runk = tb3.Text;
            var fireObject = tb4.Text;
            var owner = tb6.Text;
            var damageResult = tb7.Text;
            var causeOfFire = tb8.Text;
            var costOfDamage = Int32.Parse(tb9.Text);
            var costOfSalvage = Int32.Parse(tb10.Text);
            var leader = tb11.Text;
            var fireInspector = tb12.Text;

            Fire fire = new Fire(adress, runk, workTime, fieldUnits,
                                applicant, fireObject, owner, damageResult,
                                causeOfFire, costOfDamage, costOfSalvage, leader, fireInspector, UserController.CurrentUser.Name);
            return fire;
        }
    }
}
