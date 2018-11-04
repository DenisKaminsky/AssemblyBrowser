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

        //список категорий
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

        //сканирование полей
        public void ScanFields()
        {
            FieldInfo[] fields = _type.GetFields(BindingFlags.Static| BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {          
                Elements[0].AddClassificationElement(new Field(field));
            }
        }

        //сканирование свойств
        public void ScanProperties()
        {
            PropertyInfo[] properties = _type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {    
                Elements[1].AddClassificationElement(new Property(property));
            }
        }
        
        //сканирование методов
        public void ScanMethods()
        {
            MethodInfo[] methods = _type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                Elements[2].AddClassificationElement(new Method(method));
            }
        }
    }
}
