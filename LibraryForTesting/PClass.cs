using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTesting
{
    public interface IC
    {
        string P { get; set; }
    }

    public class PClass
    {
        private int _intField;
        private string _stringField;
        public  float _floatField;

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
}

namespace StructEnumDelegate
{
    enum Operation
    {
        Add = 2,
        Subtract = 4,
        Multiply = 8,
        Divide = 16
    }

    delegate void Message();

    struct User
    {
        public string name;
        public int age;

        public void ChooseOperation()
        {
            Operation op;
            op = Operation.Add;
        }
    }
}
