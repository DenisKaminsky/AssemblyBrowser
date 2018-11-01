namespace AssemblyBrowser
{
    public class Parameter : Field
    {
        public Parameter(string name,string type):base(name,type)
        {
            Name = name;
            Type = type;
        }
    }
}
