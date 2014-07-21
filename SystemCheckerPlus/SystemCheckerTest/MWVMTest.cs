using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using SystemCheckerPlus;
using SystemCheckerPlus.ViewModel;

namespace SystemCheckerTest
{
    [TestClass]
    public class MWVMTest
    {
        [TestMethod]
        public void PerfTimer()
        {
            MainViewModel testMWVM = new MainViewModel();
            Thread.Sleep(2000);
            float sample1 = testMWVM.CPUUsage;
            Assert.IsTrue(testMWVM.CPUUsage != 0);
            Thread.Sleep(1500);
            float sample2 = testMWVM.CPUUsage;
            Assert.AreNotEqual(sample1, sample2);
        }
    }
}