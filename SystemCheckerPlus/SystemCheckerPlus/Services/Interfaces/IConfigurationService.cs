using SystemCheckerPlus.Models;
using SystemCheckerPlus.Models.Interfaces;
namespace SystemCheckerPlus.Services.Interfaces
{
    public interface IConfigurationService
    {
        Application[] LoadConfiguration(string path);
        void CreateNewConfiguration(string path);
        void SaveApplication(string path, IApplication toSave);
    }
}