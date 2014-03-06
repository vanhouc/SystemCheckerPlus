using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCheckerPlus
{
    public interface IProcessInfo
    {
        Task<float> TotalCPUAsync();

        Task<float> ProcessCPUAsync(string processName);

        float ProcessPrivateMemory(string processName);
    }
}
