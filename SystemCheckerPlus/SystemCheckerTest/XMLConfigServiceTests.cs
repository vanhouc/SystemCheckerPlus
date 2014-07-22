using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SystemCheckerTest
{
    [TestClass]
    public class XMLConfigServiceTests
    {
        [TestMethod]
        public void CreateNew()
        {
            if (File.Exists("TestXML.xml"))
                Assert.Fail("There is an existing file");

        }
    }
}
