using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SystemCheckerPlus
{
    public class ProcessService : IProcessInfo
    {
        private static readonly ProcessService instance = new ProcessService();

        private ProcessService() { }

        public static ProcessService Instance
        {
            get
            {
                return instance;
            }
        }
        async public Task<float> TotalCPUAsync()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            await Task.Delay(1000);
            return cpuCounter.NextValue();
        }
        public float AvailableMemory()
        {
            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");
            return memCounter.NextValue();
        }

        async public Task<float> ProcessCPUAsync(string processName)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Process";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = processName;
            cpuCounter.NextValue();
            await Task.Delay(1000);
            return cpuCounter.NextValue();
        }

        public float ProcessPrivateMemory(string processName)
        {
            Process proc = Process.GetProcessesByName(processName).First();
            return proc.PrivateMemorySize64;
        }
    }
}