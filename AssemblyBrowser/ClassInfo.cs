using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class ClassInfo
    {
        private string _name;
        private Type _type;
        private List<IField> _fields;
        private List<IField> _properties;
        private List<IField> _methods;
        private List<ClassInfoElement> _elements;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<IField> Fields
        {
            get
            {
                return _fields;
            }

            set
            {
                _fields = value;
            }
        }

        public List<IField> Properties
        {
            get
            {
                return _properties;
            }

            set
            {
                _properties = value;
            }
        }

        public List<IField> Methods
        {
            get
            {
                return _methods;
            }

            set
            {
                _methods = value;
            }
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
            _name = type.Name;
            Fields = new List<IField>();
            Properties = new List<IField>();
            Methods = new List<IField>();
            Elements = new List<ClassInfoElement>();
            ScanFields();
            ScanProperties();
            ScanMethods();
            AddElements();
        }

        public void AddElements()
        {            
            Elements.Add(new ClassInfoElement("Fields", Fields));
            Elements.Add(new ClassInfoElement("Properties", Properties));
            Elements.Add(new ClassInfoElement("Methods", Methods));
        }

        public void ScanFields()//= BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        {
            FieldInfo[] fields = _type.GetFields(BindingFlags.Static| BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Fields.Add(new Field(field.Name,field.FieldType.FullName));
            }
        }

        public void ScanProperties()
        {
            PropertyInfo[] properties = _type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Properties.Add(new Property(property.Name,property.GetType().Name));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = _type.GetMethods();

            foreach (MethodInfo method in methods)
            {                
                Methods.Add(new Method(method));
            }
        }
    }
}
