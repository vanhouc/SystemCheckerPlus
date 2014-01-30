using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace SystemCheckerPlus
{
    class XMLService
    {
        private string _xmlSource;

        public XMLService(string xmlSource)
        {
            if (File.Exists(xmlSource))
            {
                _xmlSource = xmlSource;
            }
            else
            {
                throw new FileNotFoundException(String.Format("Could not find file: {0}", xmlSource));
            }
        }
    }
}
