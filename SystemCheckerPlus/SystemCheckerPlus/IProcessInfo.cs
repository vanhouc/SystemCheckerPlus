using System.Threading.Tasks;

namespace SystemCheckerPlus
{
    public interface IProcessInfo
    {
        Task<float> ProcessCPUAsync(string processName);

        float ProcessPrivateMemory(string processName);

        Task<float> TotalCPUAsync();
    }
}