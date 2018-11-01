using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{    
    public class Method
    {
        private string _name;
        private string _returnType;
        public List<Property> _properties;

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

        public void GetParams(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                _properties.Add(new Property(parameter.Name, parameter.ParameterType.Name));
            }
        }
    }
}
