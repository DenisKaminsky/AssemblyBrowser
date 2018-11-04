using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTesting
{
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
