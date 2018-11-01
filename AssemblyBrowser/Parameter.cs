using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class Parameter : Field
    {
        public Parameter(string name,string type):base(name,type)
        {
            Name = name;
            Type = type;
        }
    }
}
