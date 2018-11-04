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
            string type = field.FieldType.Name;

            if (field.FieldType.IsGenericType)
                type = field.FieldType.Name + "<" + GetGenericType(field.FieldType.GenericTypeArguments) + ">";
            _name = AttributeBuilder.GetFieldAtributes(field) + type + " " +field.Name;
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
