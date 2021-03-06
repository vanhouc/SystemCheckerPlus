﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using SystemCheckerPlus;

namespace SystemCheckerTest
{
    [TestClass]
    public class MWVMTest
    {
        [TestMethod]
        public void PerfTimer()
        {
            MainWindowViewModel testMWVM = new MainWindowViewModel();
            Thread.Sleep(2000);
            float sample1 = testMWVM.CPUUsage;
            Assert.IsTrue(testMWVM.CPUUsage != 0);
            Thread.Sleep(1500);
            float sample2 = testMWVM.CPUUsage;
            Assert.AreNotEqual(sample1, sample2);
        }
    }
}