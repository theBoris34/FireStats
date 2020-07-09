using Microsoft.VisualStudio.TestTools.UnitTesting;
using FireStats.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {       
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var userType = "Тип";
            var adress = "Адрес";
            var personnel = 13;
            var fireTruck = 8;
            //Act
            var controller = new UserController(userName);
            controller.SetNewUserData(userType, adress, personnel, fireTruck);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(userType, controller.CurrentUser.UserType.Name);
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
    }
}