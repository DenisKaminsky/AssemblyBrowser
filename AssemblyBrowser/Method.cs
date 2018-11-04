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
            string returnType = GetParameterType(methodInfo.ReturnParameter.ParameterType);
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
                modificator = "";
                if (parameter.IsOut)
                    modificator = "out ";
                if (parameter.IsIn)
                    modificator = "in ";
                if (parameter.ParameterType.IsByRef && !parameter.IsOut)
                    modificator = "ref ";
                Name += (modificator + GetParameterType(parameter.ParameterType) + " "+ parameter.Name);
                if (counter != parameters.Length)
                    Name += ", ";
                counter++;               
            }
            Name += ")";
        }

        private string GetParameterType(Type t)
        {
            if (t.IsGenericType)
                return t.Name + "<" + GetGenericType(t.GenericTypeArguments) + ">";
            else
                return t.FullName;
        }

        private string GetGenericType(Type[] types)
        {
            string result = "";
            foreach (Type type in types)
            {
                if (type.IsGenericType)
                    result += type.Name + "<" + GetGenericType(type.GenericTypeArguments) + ">";
                else
                    result += type.Name;
            }

            return result;
        }
    }
}
