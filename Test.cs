using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLab3
{
    internal class Test
    {
        public string NameTest { get; set; }
        public bool Pass { get; set; }



        public Test(string nameTest, bool pass)
        {
            NameTest = nameTest;
            Pass = pass;
        }

        public Test()
        {
            NameTest = string.Empty;
            Pass = false;
        }



        public object DeepCopy()
        {
            Test copy = new Test(NameTest, Pass);
            return copy;
        }



        public override string ToString()
        {
            return $"\tTest name: {NameTest}    Result: {Pass}";
        }




        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Test))
            {
                return false;
            }
            Test person = (Test)obj;
            return NameTest == person.NameTest && Pass == person.Pass;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
