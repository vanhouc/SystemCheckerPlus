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
            VersusApplication[] testArray = new VersusApplication[0];
            VersusAppList testController = new VersusAppList(testArray);
            CollectionAssert.AreEqual(new string[] { "No Applications Present" }, testController.GetAllProp("DisplayName"));
        }
        [TestMethod]
        public void GetAllPropDN()
        {
            VersusApplication[] testArray = { new VersusApplication(), new VersusApplication("Just Checking"), new VersusApplication() };
            VersusAppList testController = new VersusAppList(testArray);
            CollectionAssert.AreEqual(new string[] { "Test Application", "Just Checking", "Test Application" }, testController.GetAllProp("DisplayName"));
        }
        [TestMethod]
        public void GetElement()
        {
            VersusApplication[] testArray = { new VersusApplication(), new VersusApplication("Just Checking"), new VersusApplication() };
            VersusAppList testController = new VersusAppList(testArray);
            Assert.AreEqual(testArray[1], testController.GetElement(typeof(VersusApplication), "DisplayName", "Just Checking")[0]);
        }
    }
}
