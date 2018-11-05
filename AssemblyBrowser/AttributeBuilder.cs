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
        //модификаторы доступа для классов
        private static string GetClassAccessModifiers(Type type)
        {            
            if (type.IsNestedPrivate)
                return "private ";
            if (type.IsNestedFamily)
                return "protected ";
            if (type.IsNestedAssembly)
                return "internal ";
            if (type.IsNestedFamORAssem)
                return "protected internal ";
            if (type.IsNestedFamANDAssem)
                return "private protected ";
            if (type.IsNestedPublic || type.IsPublic)
                return "public ";
            if (type.IsNotPublic)
                return "private ";
            else
                return "public ";
        }

        //модификаторы доступа полей
        private static string GetFieldAccessModifiers(FieldInfo field)
        {    
            if (field.IsAssembly)
                return "internal ";
            if (field.IsFamily)
                return "protected ";
            if (field.IsFamilyOrAssembly)
                return "protected internal ";
            if (field.IsFamilyAndAssembly)
                return "private protected ";
            if (field.IsPrivate)
                return "private ";
            else
                return "public ";
        }

        //модификаторы доступа свойств
        private static string GetPropertyAccessModifiers(PropertyInfo property)
        {
            List<string> modifiers = new List<string> { "private ", "private protected ", "protected internal ", "protected ", "internal ", "public " };
            if (property.SetMethod == null)
                return GetMethodAccessModifiers(property.GetGetMethod(true));
            if (property.GetMethod == null)
                return GetMethodAccessModifiers(property.GetSetMethod(true));
            var max = Math.Max( modifiers.IndexOf(GetMethodAccessModifiers(property.GetGetMethod(true))),
            modifiers.IndexOf(GetMethodAccessModifiers(property.GetSetMethod(true))));
            return modifiers[max];
        }

        //модификаторы доступа методов
        private static string GetMethodAccessModifiers(MethodInfo method)
        {
            if (method.IsAssembly)
                return "internal ";
            if (method.IsFamily)
                return "protected ";
            if (method.IsFamilyOrAssembly)
                return "protected internal ";
            if (method.IsFamilyAndAssembly)
                return "private protected ";
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

        //модификаторы поля
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

        //модификаторы наследования метода
        private static string GetMethodModifiers(MethodInfo method)
        {
            if (method.IsAbstract && !method.DeclaringType.IsInterface)
                return "abstract ";
            if (!method.Equals(method.GetBaseDefinition()))
                return "override ";
            if (method.IsStatic)
                return "static ";
            if (method.IsVirtual && !method.IsFinal && method.Equals(method.GetBaseDefinition()) && !method.DeclaringType.IsInterface)
                return "virtual ";
            return "";
        }

        //модификаторы параметров 
        private static string GetParameterModifiers(ParameterInfo parameter)
        {
            if (parameter.IsOut)
                return "out ";
            if (parameter.IsIn)
                return "in ";
            if (parameter.ParameterType.IsByRef && !parameter.IsOut)
                return "ref ";
            return "";
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

        //модификаторы для свойств
        public static string GetPropertyAtributes(PropertyInfo property)
        {
            return GetPropertyAccessModifiers(property);
        }

        //модификаторы для методов
        public static string GetMethodsAtributes(MethodInfo method)
        {
            return GetMethodAccessModifiers(method) + GetMethodModifiers(method);
        }
        //модификаторы для параметров
        public static string GetParamsAtributes(ParameterInfo parameter)
        {
            return GetParameterModifiers(parameter);
        }
    }
}
