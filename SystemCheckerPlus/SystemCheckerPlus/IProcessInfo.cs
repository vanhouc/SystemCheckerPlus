using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemCheckerPlus
{
    interface IProcessInfo
    {
        public float TotalCPUUsage();

        public float ProcessCPUUsage(string processName);

        public float ProcessPrivateMemory(string processName);
    }
}
