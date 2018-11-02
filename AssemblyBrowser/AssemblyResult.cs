using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class AssemblyResult
    {
        private List<NamespaceInfo> _namespaces;

        public List<NamespaceInfo> Namespaces
        {
            get
            {
                return _namespaces;
            }

            set
            {
                _namespaces = value;
            }
        }

        public AssemblyResult()
        {
            Namespaces = new List<NamespaceInfo>();
        }

        //добавляем namespace
        public void AddNamespace(NamespaceInfo namespaceInfo)
        {
            Namespaces.Add(namespaceInfo);
        }

        //проверяем наличие в списке namespace
        public NamespaceInfo FindNamespace(string name)
        {
            return Namespaces.Find(x => x.Name == name);
        }

        //очищаем результат
        public void Clear()
        {
            Namespaces.Clear();
        }
    }
}
