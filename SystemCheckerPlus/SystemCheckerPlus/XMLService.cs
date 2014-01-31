using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
namespace SystemCheckerPlus
{
    public class XMLService
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
    }
}
