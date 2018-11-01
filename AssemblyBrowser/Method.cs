using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{    
    public class Method
    {
        private string _name;
        private string _returnType;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ReturnType
        {
            get { return _returnType; }
            set { _returnType = value; }
        }

        public Method(MethodInfo methodInfo)
        {
            _name = methodInfo.Name;
            _returnType = methodInfo.ReturnParameter.GetType().Name;
        }



    }
}
