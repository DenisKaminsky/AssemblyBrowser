using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyBrowser;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyBrowser.AssemblyBrowser browser = new AssemblyBrowser.AssemblyBrowser();
            AssemblyResult res =  browser.Browse("C:\\Users\\Денис\\Documents\\GitHub\\Faker\\Plugins\\bin\\Debug\\Plugins.dll");
            IList l = new List<AssemblyResult>();
            l.Add(res); 

        }
    }
}
