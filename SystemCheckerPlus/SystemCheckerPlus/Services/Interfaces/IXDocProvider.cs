using System.Xml.Linq;

namespace SystemCheckerPlus.Services.Interfaces
{
    public interface IXDocProvider
    {
        XDocument Doc
        {
            get;
        }
    }
}