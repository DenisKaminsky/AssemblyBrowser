using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{    
    public class Method
    {
        private string _name;
        private string _returnType;
        private List<Property> _properties;

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

        public List<Property> Properties
        {
            get
            {
                return _properties;
            }

            set
            {
                _properties = value;
            }
        }

        public Method(MethodInfo methodInfo)
        {
            _name = methodInfo.Name;
            _returnType = methodInfo.ReturnParameter.GetType().Name;
            Properties = new List<Property>();
        }

        public void GetParams(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Properties.Add(new Property(parameter.Name, parameter.ParameterType.Name));
            }
        }
    }
}
