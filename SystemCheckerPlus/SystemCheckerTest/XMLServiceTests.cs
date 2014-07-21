using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using SystemCheckerPlus;
using SystemCheckerPlus.Models;
using SystemCheckerPlus.Services;
using SystemCheckerPlus.Services.Interfaces;

namespace SystemCheckerTest
{
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

    public class MockXML3 : IXDocProvider
    {
        private XDocument _doc;

        public MockXML3()
        {
            _doc = new XDocument(
                new XElement("Applications",
                    new XElement("Application",
                        new XElement("DisplayName", "Name"),
                        new XElement("Folder", "Bar is minimum"),
                        new XElement("BUPFiles",
                            new XElement("file", "\\stuff")),
                        new XElement("Executable", "Name.exe")
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

    [TestClass]
    public class XMLServiceTests
    {
        [TestMethod]
        public void GetAppData()
        {
            XMLService elementTester = new XMLService(new MockXML3());
            Application testApp = elementTester.GetAppData(new string[] { "Applications", "Application" })[0];
            Assert.IsTrue(testApp.DisplayName == "Name");
            Assert.IsTrue(testApp.AppFolder == "Bar is minimum");
            CollectionAssert.AreEquivalent(new string[] { "\\stuff" }, testApp.BUPFiles);
        }

        [TestMethod]
        public void GetChildValues()
        {
            XMLService elementTester = new XMLService(new MockXML2());
            CollectionAssert.AreEquivalent(new string[] { "Bar is maximum", "Bar is minimum" }, elementTester.GetChildValues(new string[] { "Applications", "Foo" }, "FooBar"));
        }

        [TestMethod]
        public void GetCorrectElement()
        {
            XMLService elementTester = new XMLService(new MockXML());
            Assert.AreEqual("Bar is maximum", elementTester.GetElementValue(new string[] { "Applications", "Foo", "FooBar" }));
        }
    }
}