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
        private XDocument doc;
        private IXDocProvider provider;
        /// <summary>
        /// Provides methods for manipulating an XML document
        /// </summary>
        /// <param name="provider">A Provider class that will facilitate XDocument state</param>
        public XMLService(IXDocProvider provider)
        {
            this.provider = provider;
            if (this.provider.Doc != null)
                doc = this.provider.Doc;
        }
        /// <summary>
        /// Returns the value of a unique XML element
        /// </summary>
        /// <param name="elementChain">Logical heirarchy with the desired element being the last in the chain</param>
        /// <returns>array of the specified element</returns>
        public string GetElementValue(string[] elementChain)
        {
            IEnumerable<XElement> scope = doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++ )
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Single(x => x.Name == elementChain[elementChain.Length - 1]).Value;
        }
        /// <summary>
        /// Returns value of the specified child for all children of an XML element
        /// </summary>
        /// <param name="elementChain">Logical heirarchy with the desired element being the last in the chain</param>
        /// <param name="childProperty"></param>
        /// <returns>array of values from the children with the specified name</returns>
        public string[] GetChildValues(string[] elementChain, string childProperty)
        {
                        IEnumerable<XElement> scope = doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++ )
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Elements(childProperty).Select(x => x.Value).ToArray();
        }
        /// <summary>
        /// Creates a list of elements from a list of XML elements
        /// </summary>
        /// <param name="elementChain">Logical heirarchy with the name of the desired element being the last in the chain</param>
        /// <returns>array of application</returns>
        public Application[] GetAppData(string[] elementChain)
        {
            IEnumerable<XElement> scope = doc.Descendants();
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
