using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using AssemblyBrowser;
using LibraryForTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class BrowserTest
    {
        private AssemblyResult _result;

        [TestInitialize]

        public void Initialize()
        {
            var dir = Directory.GetCurrentDirectory();
            AssemblyBrowser.AssemblyBrowser browser = new AssemblyBrowser.AssemblyBrowser();

            //DirectoryInfo parent = dir.Parent.Parent.Parent;
            //_result = browser.Browse();
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
