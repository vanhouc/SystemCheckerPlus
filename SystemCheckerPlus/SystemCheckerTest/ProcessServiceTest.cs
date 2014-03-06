using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemCheckerPlus;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SystemCheckerTest
{
    [TestClass]
    public class ProcessServiceTest
    {
        [TestMethod]
        public void TestAsyncPoll()
        {
            ProcessService testPService = ProcessService.Instance;
            float cpu = testPService.TotalCPUAsync().Result;
            Assert.IsNotNull(cpu);
        }
        [TestMethod]
        public void TestMultiplePolls()
        {
            ProcessService testPService = ProcessService.Instance;
            float[] testResults = new float[3];
            for (int i = 0; i < 3; i++)
            {
                testResults[i] = testPService.TotalCPUAsync().Result;
            }
            CollectionAssert.AllItemsAreNotNull(testResults);
        }
        [TestMethod]
        public void TestSynchronousPoll()
        {
            ProcessService testPService = ProcessService.Instance;
            float cpu = testPService.TotalCPUAsync().Result;
            Assert.IsNotNull(cpu);
        }
        [TestMethod]
        public void TestProcessPoll()
        {
            ProcessService testPService = ProcessService.Instance;
            Process thisProc = Process.GetCurrentProcess();
            float cpuProc = testPService.ProcessCPUAsync(thisProc.ProcessName).Result;
            Assert.IsNotNull(cpuProc);
        }
    }
}
