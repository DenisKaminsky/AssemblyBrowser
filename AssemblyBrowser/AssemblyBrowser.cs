using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class AssemblyBrowser
    {
        private Assembly _asm;
        private AssemblyResult _result;

        public AssemblyBrowser()
        {
            _result = new AssemblyResult();
        }

        //сканирование сборки
        public AssemblyResult Browse(string filename)
        {
            Type[] types;
            NamespaceInfo searchResult;

            _asm = Assembly.LoadFrom(filename);
            types = _asm.GetTypes();
            _result.Clear();
            foreach (var type in types)
            {
                searchResult = _result.FindNamespace(type.Namespace);
                if (searchResult == null)
                {
                    searchResult = new NamespaceInfo(type.Namespace);
                    _result.AddNamespace(searchResult);
                }
                searchResult._classes.Add(new ClassInfo(type));                
            }
            return _result;
        }
    }
}
