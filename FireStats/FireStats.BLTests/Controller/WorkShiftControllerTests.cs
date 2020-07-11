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
    public class WorkShiftControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            List<User> fieldUnits = new List<User>();
            fieldUnits.Add(new User("pch1"));
            fieldUnits.Add(new User("pch2"));
            List<string> injured = new List<string>();
            injured.Add( "postr1");
            injured.Add("postr2");
            var rundAdress = Guid.NewGuid().ToString();
            var test = Guid.NewGuid().ToString();
            var workTime = new WorkTime(DateTime.Now);
            var rnd = new Random();
            var userController = new UserController(userName);
            var workShiftController = new WorkShiftController(userController.CurrentUser);

            var fire = new Fire(rundAdress, 3, workTime, fieldUnits, test, test, test, test, test, rnd.Next(0, 1000000), rnd.Next(0, 1000000), test, test);
            var emergancy = new Emergency(rundAdress, workTime, fieldUnits, test, test, test, test, test, injured);


            //Act
            workShiftController.Add(fire);
            workShiftController.Add(emergancy);

            //Assert
            Assert.IsTrue(workShiftController.WorkShift.Fires.Count > 0);
            //Assert.AreEqual(fire.FireRank.ToString(), workShiftController.WorkShift.Fires.Count);
        }
    }
}