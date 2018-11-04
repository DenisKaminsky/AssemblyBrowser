using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{    
    public class Method: IField
    {
        private string _name;
        private string _returnType;
        private List<Property> _parameters;

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

        public List<Property> Parameters
        {
            get
            {
                return _parameters;
            }

            set
            {
                _parameters = value;
            }
        }

        public Method(MethodInfo methodInfo)
        {
            _name = methodInfo.Name;
            _returnType = methodInfo.ReturnParameter.GetType().Name;
            Parameters = new List<Property>();
        }

        public void GetParams(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Parameters.Add(new Property(parameter.Name, parameter.ParameterType.Name));
            }
        }
    }
}
