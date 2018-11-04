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
            string returnType = methodInfo.ReturnParameter.ParameterType.ToString();
            _name = AttributeBuilder.GetAtributes(methodInfo.GetType())+ methodInfo.ToString();
        }

        private void GetParams(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            Name += "(";
            foreach (ParameterInfo parameter in parameters)
            {
                Name += (parameter.ParameterType.Name + " "+ parameter.Name);
            }
            Name += ")";
        }
    }
}
