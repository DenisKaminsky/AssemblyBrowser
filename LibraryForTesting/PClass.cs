using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTesting
{
    public interface IInterface
    {
        string P { get; set; }
    }

    public sealed class PClass
    {
        internal class NestedClass
        {
        }

        protected internal int _intField;
        internal string _stringField;
        private  float _floatField;
        public static int _intnum;        

        public int IntProperty
        {
            get
            {
                return _intField;
            }

            set
            {
                _intField = value;
            }
        }

        public void Method1(ref int num, float num2, out string str)
        {
            str = "hello";
        }

        public static int Method2()
        {
            return 0;
        }
    }

    public abstract class PClass2
    {
        public abstract int a { get; set; }
    }
}

/*namespace StructEnumDelegate
{
    public enum Operation
    {
        Add = 2,
        Subtract = 4,
        Multiply = 8,
        Divide = 16
    }

    public delegate void Message();

    public struct User
    {
        public string name;
        public int age;

        public void ChooseOperation()
        {
            Operation op;
            op = Operation.Add;
        }
    }
}*/
