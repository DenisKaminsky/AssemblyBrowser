using System.Reflection;

namespace AssemblyBrowser
{
    public class Field: IField
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Field(string name, string type)
        {
            _name = type+" "+name;
        }
    }
}
