using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class AssemblyResult
    {
        public List<NamespaceInfo> _namespaces { get; set; } 

        public AssemblyResult()
        {
            _namespaces = new List<NamespaceInfo>();
        }

        //добавляем namespace
        public void AddNamespace(NamespaceInfo namespaceInfo)
        {
            _namespaces.Add(namespaceInfo);
        }

        //возвращаем резульат
        public List<NamespaceInfo> GetResult()
        {
            return _namespaces;
        }

        //проверяем наличие в списке namespace
        public NamespaceInfo FindNamespace(string name)
        {
            return _namespaces.Find(x => x.Name == name);
        }

        //очищаем результат
        public void Clear()
        {
            _namespaces.Clear();
        }
    }
}
