using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
namespace SystemCheckerPlus
{
    public class XMLService : SystemCheckerPlus.IXMLService
    {
        private XDocument _doc;
        public XMLService(IXDocProvider loader)
        {
            if (loader.Doc != null)
                _doc = loader.Doc;
        }
        public string GetElementValue(string[] elementChain)
        {
            IEnumerable<XElement> scope = _doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++ )
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Single(x => x.Name == elementChain[elementChain.Length - 1]).Value;
        }
        public string[] GetChildValues(string[] elementChain, string childProperty)
        {
                        IEnumerable<XElement> scope = _doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++ )
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Elements(childProperty).Select(x => x.Value).ToArray();
        }
        public Application[] GetAppData(string[] elementChain)
        {
            IEnumerable<XElement> scope = _doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++)
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            Application[] appList = (from app in scope
                                     where app.Name == elementChain[elementChain.Length -1]
                                     select new Application()
                                     {
                                         DisplayName = app.Element("DisplayName").Value,
                                         AppFolder = app.Element("Folder").Value,
                                         BUPFiles = app.Element("BUPFiles").Elements().Select(x => x.Value).ToArray(),
                                     }).ToArray();
            return appList;
        }
    }
}
