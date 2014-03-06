using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemCheckerPlus;
using System.Diagnostics;

namespace SystemCheckerTest
{
    [TestClass]
    public class VersusAppListTests
    {
        [TestMethod]
        public void ConstructorEmptyArray()
        {
            Application[] testArray = new Application[0];
            AppService testController = new AppService(testArray);
            CollectionAssert.AreEqual(new string[] { "No Applications Present" }, testController.GetAllProp("DisplayName"));
        }
        [TestMethod]
        public void GetAllPropDN()
        {
            Application[] testArray = { new Application(), new Application("Just Checking"), new Application() };
            AppService testController = new AppService(testArray);
            CollectionAssert.AreEqual(new string[] { "Test Application", "Just Checking", "Test Application" }, testController.GetAllProp("DisplayName"));
        }
        [TestMethod]
        public void GetElement()
        {
            Application[] testArray = { new Application(), new Application("Just Checking"), new Application() };
            AppService testController = new AppService(testArray);
            Assert.AreEqual(testArray[1], testController.GetElement(typeof(Application), "DisplayName", "Just Checking")[0]);
        }
    }
}
