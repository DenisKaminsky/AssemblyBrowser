using System.IO;
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

        [TestMethod]
        public void ClassTest()
        {
            Assert.IsNotNull(_result.Namespaces[0].Classes);
            Assert.IsNotNull(_result.Namespaces[1].Classes);
            Assert.AreEqual(3, _result.Namespaces[0].Classes.Count);
            Assert.AreEqual(4, _result.Namespaces[1].Classes.Count);
        }

        [TestMethod]
        public void FieldsTest()
        {
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[0].ClassificationElements);
            Assert.AreEqual(6, _result.Namespaces[1].Classes[1].Elements[0].ClassificationElements.Count);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[1].ClassificationElements);
            Assert.AreEqual(2, _result.Namespaces[1].Classes[1].Elements[1].ClassificationElements.Count);
        }

        [TestMethod]
        public void MethodsTest()
        {
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[2].ClassificationElements);
            Assert.AreEqual(3, _result.Namespaces[1].Classes[1].Elements[2].ClassificationElements.Count);
        }
    }
}
