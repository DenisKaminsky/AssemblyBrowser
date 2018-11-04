using System;
using System.Reflection;

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

        public Property(PropertyInfo property)
        {
            _name = property.PropertyType.FullName + " " + property.Name;//AttributeBuilder.GetFieldAtributes(type) + 
        }
    }
}
