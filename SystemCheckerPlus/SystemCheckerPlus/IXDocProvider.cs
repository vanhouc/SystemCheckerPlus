using System.Xml.Linq;

namespace SystemCheckerPlus
{
    public interface IXDocProvider
    {
        XDocument Doc
        {
            get;
        }
    }
}