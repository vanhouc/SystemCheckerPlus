using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
namespace SystemCheckerPlus
{
    class XMLService
    {
        private XDocument doc;
        public XMLService(string xmlSource)
        {
            if (File.Exists(xmlSource))
            {
                doc = XDocument.Load(xmlSource);
            }
            else
            {
                throw new FileNotFoundException(String.Format("Could not find file: {0}", xmlSource));
            }
        }
    }
}
