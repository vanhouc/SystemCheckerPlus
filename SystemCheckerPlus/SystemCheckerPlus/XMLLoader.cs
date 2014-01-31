using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace SystemCheckerPlus
{
    class XMLLoader : IXDocProvider
    {
        private XDocument _doc;

        public XDocument Doc
        {
            get { return _doc; }
            set { _doc = value; }
        }
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
    }
}
