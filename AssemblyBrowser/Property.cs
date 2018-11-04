using System;

namespace AssemblyBrowser
{
    public class Property:IField
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Property(string name,Type type)
        {
            _name = type.FullName + " " + name;//AttributeBuilder.GetFieldAtributes(type) + 
        }
    }
}
