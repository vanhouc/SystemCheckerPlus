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
        [TestMethod]
        public void GetChildValues()
        {
            XMLService elementTester = new XMLService(new MockXML2());
            CollectionAssert.AreEquivalent(new string[] {"Bar is maximum", "Bar is minimum"}, elementTester.GetChildValues(new string[] { "Applications", "Foo" }, "FooBar"));
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
    public class MockXML2 : IXDocProvider
    {
        private XDocument _doc;
        public MockXML2()
        {
            _doc = new XDocument(
                new XElement("Applications",
                    new XElement("Foo",
                        new XElement("FooBar", "Bar is maximum"),
                        new XElement("FooBar", "Bar is minimum")
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
