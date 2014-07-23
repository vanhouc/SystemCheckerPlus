﻿using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SystemCheckerPlus.Services.Interfaces;

namespace SystemCheckerPlus.Services
{
    public static class ProcessService
    {
        public static float AvailableMemory()
        {
            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");
            return memCounter.NextValue();
        }

        public static float ProcessCPUAsync(string processName)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Process";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = processName;
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            return cpuCounter.NextValue();
        }

        public static float ProcessPrivateMemory(string processName)
        {
            Process proc = Process.GetProcessesByName(processName).First();
            return proc.PrivateMemorySize64;
        }

        public static float TotalCPUAsync()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            return cpuCounter.NextValue();
        }
    }
}