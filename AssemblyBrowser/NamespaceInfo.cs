using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class NamespaceInfo
    {
        private string _name;
        private List<ClassInfo> _classes;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<ClassInfo> Classes
        {
            get
            {
                return _classes;
            }

            set
            {
                _classes = value;
            }
        }

        public NamespaceInfo(string name)
        {
            _name = name;
            Classes = new List<ClassInfo>();
        }

        public void AddClass(ClassInfo classInfo)
        {
            Classes.Add(classInfo);
        }
    }
}
