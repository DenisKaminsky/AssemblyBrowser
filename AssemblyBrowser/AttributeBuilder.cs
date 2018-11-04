using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public static class AttributeBuilder
    {
        //модификаторы для классов
        public static string GetClassAccessModifiers(Type type)
        {            
            if (type.IsNestedPrivate)
                return "private ";
            if (type.IsNestedFamily)
                return "protected ";
            if (type.IsNestedAssembly)
                return "internal ";
            if (type.IsNestedFamORAssem)
                return "protected internal ";
            if (type.IsNestedPublic || type.IsPublic)
                return "public ";
            if (type.IsNotPublic)
                return "private ";
            else
                return "public ";
        }

        //модификаторы доступа полей
        public static string GetFieldAccessModifiers(FieldInfo field)
        {
            if (field.IsAssembly)
                return "internal ";
            if (field.IsFamily)
                return "protected ";
            if (field.IsFamilyOrAssembly)
                return "protecred internal ";
            if (field.IsPrivate)
                return "private ";
            else
                return "public ";
        }

        //модификаторы наследования класса
        private static string GetClassModifiers(Type type)
        {
            if (type.IsAbstract && type.IsSealed)
                return "static ";
            if (type.IsSealed)
                return "sealed ";
            if (type.IsAbstract)
                return "abstract ";
            return "";
        }

        //модификаторы наследования поля
        private static string GetFieldModifiers(FieldInfo field)
        {
            if (field.IsStatic)
                return "static ";
            return "";
        }

        private static string GetClass(Type type)
        {
            if (type.IsInterface)
                return "interface ";
            if (type.IsEnum)
                return "enum ";
            if (type.IsValueType)
                return "struct ";                   
            if (type.BaseType == typeof(MulticastDelegate))
                return "delegate ";
            if (type.IsClass)
                return "class ";
            return "";
        }
                
        //модификаторы для классов, интерфейсов и т.д
        public static string GetClassAtributes(Type type)
        {
            if (type.IsClass && (type.BaseType != typeof(MulticastDelegate)) )
                return GetClassAccessModifiers(type) + GetClassModifiers(type) + GetClass(type);
            return GetClassAccessModifiers(type) + GetClass(type);
        }

        //модификаторы для полей, свойств и методов
        public static string GetFieldAtributes(FieldInfo field)
        {
            return GetFieldAccessModifiers(field);// + GetFieldModifiers(type);
        }

        public static string GetAtributes(Type type)
        {
            if (type.IsInterface)
                return GetClassAccessModifiers(type) + GetClass(type);
            return GetClassAccessModifiers(type) + GetClassModifiers(type) + GetClass(type);
        }
    }
}
