﻿using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class ClassInfo
    {
        private string _name;
        private Type _type;
        public List<Field> _fields;
        public List<Property> _properties;
        public List<Method> _methods;
        
        public ClassInfo(Type type)
        {
            _type = type;
            _name = type.Name;
            _fields = new List<Field>();
            _properties = new List<Property>();
            _methods = new List<Method>();
            ScanFields();
            ScanProperties();
            ScanMethods();
        }

        public void ScanFields()//= BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        {
            FieldInfo[] fields = _type.GetFields();

            foreach (FieldInfo field in fields)
            {
                _fields.Add(new Field(field.Name,field.GetType().Name));
            }
        }

        public void ScanProperties()
        {
            PropertyInfo[] properties = _type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                _properties.Add(new Property(property.Name,property.GetType().Name));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = _type.GetMethods();

            foreach (MethodInfo method in methods)
            {                
                _methods.Add(new Method(method));
            }
        }
    }
}
