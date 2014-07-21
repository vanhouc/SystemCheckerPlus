using System;
using System.IO;
using System.Xml.Linq;
using SystemCheckerPlus.Services.Interfaces;

namespace SystemCheckerPlus.Services
{
    internal class XMLLoader : IXDocProvider
    {
        private XDocument _doc;

        public XMLLoader(string filePath)
        {
            if (File.Exists(filePath) && new FileInfo(filePath).Extension == ".xml")
            {
                try
                {
                    _doc = XDocument.Load(filePath);
                }
                catch
                {
                    throw new InvalidDataException("Invalid XML input");
                }
            }
            else
            {
                throw new FileNotFoundException(String.Format("Could not find file: {0}", filePath));
            }
        }

        public XDocument Doc
        {
            get { return _doc; }
            set { _doc = value; }
        }
    }
}