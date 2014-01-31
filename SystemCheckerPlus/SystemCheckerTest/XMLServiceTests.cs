using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemCheckerPlus;
using System.Xml.Linq;

namespace SystemCheckerTest
{
    [TestClass]
    public class XMLServiceTests
    {
        [TestMethod]
        public void GetCorrectElement()
        {
            XMLService elementTester = new XMLService(new MockXML());
            Assert.AreEqual("Bar is maximum", elementTester.GetElementValue(new string[] { "Applications", "Foo", "FooBar" }));
        }
    }
    public class MockXML : IXDocProvider
    {
        private XDocument _doc;
        public MockXML()
        {
            _doc = new XDocument(
                new XElement("Applications",
                    new XElement("Foo",
                        new XElement("FooBar", "Bar is maximum")
                        )
                    )
                );
        }
        public XDocument Doc
        {
            get
            {
                return _doc;
            }
        }
    }
}
