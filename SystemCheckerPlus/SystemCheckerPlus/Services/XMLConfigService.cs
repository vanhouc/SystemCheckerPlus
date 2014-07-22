using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using SystemCheckerPlus.Models;
using SystemCheckerPlus.Services.Interfaces;
using SystemCheckerPlus.Models.Interfaces;

namespace SystemCheckerPlus.Services
{
    internal class XMLConfigService : IConfigurationService
    {
        public Application[] LoadConfiguration(string path)
        {
            XDocument doc = XDocument.Load(path);
            Application[] appList = (from app in doc.Root.Elements()
                                     select new Application()
                                     {
                                         DisplayName = app.Element("Display").Value,
                                         Folder = app.Element("Folder").Value,
                                         Executable = app.Element("Executable").Value,
                                         Files = app.Elements("File").Select(x => x.Value).ToArray(),
                                     }).ToArray();
            return appList;
        }
        public void SaveApplication(string path, IApplication toSave)
        {
            XDocument doc = XDocument.Load(path);
            XElement toRemove = doc.Element(toSave.FileName);
            if (toRemove != null)
                toRemove.Remove();
            XElement[] files = toSave.Files.Select(f => new XElement("File", f)).ToArray();
            doc.Root.Add(
                new XElement(toSave.FileName,
                    new XElement("Display", toSave.DisplayName),
                    new XElement("Folder", toSave.Folder),
                    new XElement("Executable", toSave.Executable),
                    files));
        }
        public void CreateNewConfiguration(string path)
        {
            XDocument doc = new XDocument(
                new XElement("Applications"));
            doc.Save(path);
        }
        /// <summary>
        /// Returns value of the specified child for all children of an XML element
        /// </summary>
        /// <param name="elementChain">Logical heirarchy with the desired element being the last in the chain</param>
        /// <param name="childProperty"></param>
        /// <returns>array of values from the children with the specified name</returns>
        private string[] GetChildValues(XDocument doc, string[] elementChain, string childProperty)
        {
            IEnumerable<XElement> scope = doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++)
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Elements(childProperty).Select(x => x.Value).ToArray();
        }

        /// <summary>
        /// Returns the value of a unique XML element
        /// </summary>
        /// <param name="elementChain">Logical heirarchy with the desired element being the last in the chain</param>
        /// <returns>array of the specified element</returns>
        private string GetElementValue(XDocument doc, string[] elementChain)
        {
            IEnumerable<XElement> scope = doc.Descendants();
            for (int i = 0; i < elementChain.Length - 1; i++)
            {
                scope = scope.Single(x => x.Name == elementChain[i]).Descendants();
            }
            return scope.Single(x => x.Name == elementChain[elementChain.Length - 1]).Value;
        }
    }
}