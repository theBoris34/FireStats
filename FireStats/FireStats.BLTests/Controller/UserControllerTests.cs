using Microsoft.VisualStudio.TestTools.UnitTesting;
using FireStats.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireStats.BL.Model;

namespace FireStats.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {       
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            string[] ArrayUserTypes = new string[] { "NCUKCS", "CUKS FO", "CUKC", "EDDS", "PSCH" };
            Random rnd = new Random();
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var userType = rnd.Next(0,4);
            var adress = "Адрес";
            var personnel = 13;
            var fireTruck = 8;
            //Act
            var controller = new UserController(userName);
            controller.SetNewUserData(userType, adress, personnel, fireTruck);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(ArrayUserTypes[userType], controller.CurrentUser.UserType);
            Assert.AreEqual(adress, controller.CurrentUser.Adress);
            Assert.AreEqual(personnel, controller.CurrentUser.Personnel);
            Assert.AreEqual(fireTruck, controller.CurrentUser.FireTruck);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveFireTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var adress = Guid.NewGuid().ToString();
            var applicant = Guid.NewGuid().ToString();
            var fireObject = Guid.NewGuid().ToString();
            var owner = Guid.NewGuid().ToString();
            var damageResult = Guid.NewGuid().ToString();
            var causeOfFire = Guid.NewGuid().ToString();
            var leader = Guid.NewGuid().ToString();
            var fireInspector = Guid.NewGuid().ToString();
            var workTime = new WorkTime();
            User us1 = new User(userName);
            User us2 = new User(userName + "asd");
            List <User> UserList = new List<User>();
            UserList.Add(us1);
            UserList.Add(us2);

            //Act
            var controller = new UserController(userName);
            Fire fire = new Fire(adress, 3,workTime, UserList,applicant,fireObject,owner,damageResult,causeOfFire, 7000,9000,leader,fireInspector,"пользователь");
            controller.Add(fire);


            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(adress, controller.CurrentUser.Fires.First().Adress);
            Assert.AreEqual(applicant, controller.CurrentUser.Fires.First().Applicant);
            Assert.AreEqual(fireObject, controller.CurrentUser.Fires.First().FireObject);
            Assert.AreEqual(damageResult, controller.CurrentUser.Fires.First().DamageResult);
            Assert.AreEqual(causeOfFire, controller.CurrentUser.Fires.First().CauseOfFire);
            Assert.AreEqual(leader, controller.CurrentUser.Fires.First().Leader);
            Assert.AreEqual(fireInspector, controller.CurrentUser.Fires.First().FireInspector);
        }

        [TestMethod()]
        public void SaveEmergancyTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var adress = Guid.NewGuid().ToString();
            var applicant = Guid.NewGuid().ToString();
            var fireObject = Guid.NewGuid().ToString();
            var owner = Guid.NewGuid().ToString();
            var damageResult = Guid.NewGuid().ToString();
            var leader = Guid.NewGuid().ToString();
            var workTime = new WorkTime();
            User us1 = new User(userName);
            User us2 = new User(userName + "asd");
            List<string> inList = new List<string>() { "Пострадавший_1","Пострадавший_2"};
            List <User> UserList = new List<User>() { us1, us2 };
            
            //Act
            var controller = new UserController(userName);
            Emergency emergency = new Emergency(adress,"ЧС как ЧС, ничего особенного",workTime, UserList, applicant, fireObject, owner,damageResult, leader,inList);
            controller.Add(emergency);


            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(adress, controller.CurrentUser.Emergencies.First().Adress);
            Assert.AreEqual(applicant, controller.CurrentUser.Emergencies.First().Applicant);            
            Assert.AreEqual(fireObject, controller.CurrentUser.Emergencies.First().EmergencyObject);
            Assert.AreEqual(owner, controller.CurrentUser.Emergencies.First().Owner);
            Assert.AreEqual(damageResult, controller.CurrentUser.Emergencies.First().DamageResult);
            Assert.AreEqual(leader, controller.CurrentUser.Emergencies.First().Leader);
        }        


    }

}