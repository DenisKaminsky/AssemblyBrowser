using System;
using System.Reflection;

namespace AssemblyBrowser
{    
    public class Method: IField
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Method(MethodInfo methodInfo)
        {
            string returnType = GenericTypeConverter.GetType(methodInfo.ReturnParameter.ParameterType);
            _name = AttributeBuilder.GetMethodsAtributes(methodInfo)+returnType +" "+ methodInfo.Name;
            GetParams(methodInfo);
        }

        private void GetParams(MethodInfo methodInfo)
        {
            string modificator = "";
            int counter = 1;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            
            Name += "(";
            foreach (ParameterInfo parameter in parameters)
            {
                modificator = AttributeBuilder.GetParamsAtributes(parameter);
                Name += (modificator + GenericTypeConverter.GetType(parameter.ParameterType) + " "+ parameter.Name);
                if (counter != parameters.Length)
                    Name += ", ";
                counter++;               
            }
            Name += ")";
        }        
    }
}
