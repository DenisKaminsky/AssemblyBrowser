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

        //модификаторы доступа свойств
        public static string GetPropertyAccessModifiers(MethodInfo method)
        {
            if (method.IsAssembly)
                return "internal ";
            if (method.IsFamily)
                return "protected ";
            if (method.IsFamilyOrAssembly)
                return "protecred internal ";
            if (method.IsPrivate)
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
            string result = "";
            if (field.IsStatic && !(field.IsLiteral && !field.IsInitOnly))
                result+="static ";
            if (field.IsInitOnly)
                result+="readonly ";
            if (field.IsLiteral && !field.IsInitOnly)
                result += "const ";
            return result;
        }

        private static string GetClassification(Type type)
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
                return GetClassAccessModifiers(type) + GetClassModifiers(type) + GetClassification(type);
            return GetClassAccessModifiers(type) + GetClassification(type);
        }

        //модификаторы для полей
        public static string GetFieldAtributes(FieldInfo field)
        {
            return GetFieldAccessModifiers(field) + GetFieldModifiers(field);
        }
    }
}
