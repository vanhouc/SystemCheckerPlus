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
    public class AppServiceTest
    {
        [TestMethod]
        public void GetAllPropDN()
        {
            Application[] testArray = { new Application(), new Application("Just Checking"), new Application() };
            CollectionAssert.AreEqual(new string[] { "Test Application", "Just Checking", "Test Application" }, AppService.GetAllProp(testArray, "DisplayName"));
        }
        [TestMethod]
        public void GetElement()
        {
            Application[] testArray = { new Application(), new Application("Just Checking"), new Application() };
            Assert.AreEqual(testArray[1], AppService.GetElement(testArray, typeof(Application), "DisplayName", "Just Checking")[0]);
        }
    }
}
