using System;

namespace AssemblyBrowser
{
    public static class GenericTypeConverter
    {
        public static string GetType(Type t)
        {
            if (t.IsGenericType)
                return t.Name + "<" + GetGenericType(t.GenericTypeArguments) + ">";
            else
                return t.FullName;
        }

        private static string GetGenericType(Type[] types)
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
