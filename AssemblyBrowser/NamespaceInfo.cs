using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class NamespaceInfo
    {
        private string _name;
        public List<ClassInfo> _classes;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
           
        public NamespaceInfo(string name)
        {
            _name = name;
            _classes = new List<ClassInfo>();
        }
    }
}
