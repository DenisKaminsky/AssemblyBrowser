using System.Collections.Generic;

namespace LibraryForTesting
{
    public interface IInterface
    {
        string P { get; set; }
        void GetResult();
    }

    public sealed class PClass
    {
        public static int _intnum;
        public List<int> _list;
        public readonly int[] _mass;
        internal const string _stringField = "";
        protected internal int _intField;
        private  float _floatField;

        private static long LongProperty { get; }
        public float FloatProperty
        {
            set
            {
                _floatField = value;
            }
            get
            {
                return _floatField;
            }
        }
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

        private List<int> Method3(List<string> list)
        {
            return null;
        }
    }

    public abstract class PClass2
    {      
        public abstract int a { get; set; }

        public abstract void Method();
    }

    public class PClass3
    {
        public virtual void MethodVirt()
        {
        }
    }
}

namespace StructEnumDelegate
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
}
