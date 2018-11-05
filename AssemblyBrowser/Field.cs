using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class Field: IField
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Field(FieldInfo field)
        {                
            _name = AttributeBuilder.GetFieldAtributes(field) + GenericTypeConverter.GetType(field.FieldType) + " " +field.Name;
        }
    }
}
