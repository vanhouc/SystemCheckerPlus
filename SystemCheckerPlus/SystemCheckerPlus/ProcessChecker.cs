using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Timers;

namespace SystemCheckerPlus
{
    class ProcessChecker : IProcessInfo
    {
        private Mutex mut = new Mutex();
        private float _cpuUsage;

        public float CPUUSAGE
        {
            get { return _cpuUsage; }
            set
            {
                _cpuUsage = value;
            }
        }

        System.Timers.Timer pollTimer;
        public ProcessChecker()
        {
            pollTimer = new System.Timers.Timer(1000);
            pollTimer.Elapsed += new ElapsedEventHandler(QueuePoll);
        }
        public void QueuePoll(object source, ElapsedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetCPUUSage));
        }
        public void GetCPUUSage(object stateInfo)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            cpuCounter.NextValue();
        }
    }
}
