using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class ClassInfo
    {
        private string _name;
        private Type _type;
        private List<ClassInfoElement> _elements;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<ClassInfoElement> Elements
        {
            get
            {
                return _elements;
            }

            set
            {
                _elements = value;
            }
        }

        public ClassInfo(Type type)
        {
            _type = type;
            _name = AttributeBuilder.GetClassAtributes(type)+type.Name;
            Elements = new List<ClassInfoElement>();
            AddElements();
            ScanFields();
            ScanProperties();
            ScanMethods();
        }

        public void AddElements()
        {            
            Elements.Add(new ClassInfoElement("Fields", new List<IField>()));
            Elements.Add(new ClassInfoElement("Properties", new List<IField>()));
            Elements.Add(new ClassInfoElement("Methods", new List<IField>()));
        }

        public void ScanFields()
        {
            FieldInfo[] fields = _type.GetFields(BindingFlags.Static| BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Elements[0].AddClassificationElement(new Field(field.Name, field.FieldType.FullName));
            }
        }

        public void ScanProperties()
        {
            PropertyInfo[] properties = _type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Elements[1].AddClassificationElement(new Property(property.Name, property.GetType().Name));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = _type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Elements[2].AddClassificationElement(new Method(method));
            }
        }
    }
}
