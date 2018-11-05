using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowser;
using LibraryForTesting;

namespace AssemblyBrowserUnitTest
{
    [TestClass]
    public class BrowserTest
    {
        AssemblyResult _result;

        [TestInitialize]
        public void Initialize()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+ "\\LibraryForTesting\\bin\\Debug\\LibraryForTesting.dll";
            AssemblyBrowser.AssemblyBrowser browser = new AssemblyBrowser.AssemblyBrowser();
            
            _result = browser.Browse(path);
        }

        [TestMethod]
        public void NamespacesTest()
        {
            Assert.IsNotNull(_result.Namespaces);
            Assert.AreEqual(2, _result.Namespaces.Count);
            Assert.AreEqual(_result.Namespaces[0].Name, "namespace " + nameof(StructEnumDelegate));
            Assert.AreEqual(_result.Namespaces[1].Name, "namespace " + nameof(LibraryForTesting));
        }




    }
}
