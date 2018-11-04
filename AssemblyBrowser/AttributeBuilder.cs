using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public static class AttributeBuilder
    {
        public static string GetAccessModifiers(Type type)
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
                
        public static string GetClassAtributes(Type type)
        {
            if (type.IsClass && (type.BaseType != typeof(MulticastDelegate)) )
                return GetAccessModifiers(type) + GetClassModifiers(type) + GetClass(type);
            return GetAccessModifiers(type) + GetClass(type);
        }

        public static string GetAtributes(Type type)
        {
            if (type.IsInterface)
                return GetAccessModifiers(type) + GetClass(type);
            return GetAccessModifiers(type) + GetClassModifiers(type) + GetClass(type);
        }
    }
}
