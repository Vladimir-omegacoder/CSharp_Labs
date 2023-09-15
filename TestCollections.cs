using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab1
{
    internal class TestCollections
    {
        private List<Person> LPerson = new List<Person>();
        public List<Person> MLPerson
        {
            get { return LPerson; }
            set { LPerson = value; }
        }


        private List<string> Strings = new List<string>();
        public List<string> MStrings
        {
            get { return Strings; }
            set { Strings = value; }
        }



        private Dictionary<Person, Student> Di1 = new Dictionary<Person, Student> ();
        public Dictionary<Person, Student> MDi1
        {
            get { return Di1; }
            set { Di1 = value; }
        }



        private Dictionary<string, Student> Di2 = new Dictionary<string, Student> ();
        public Dictionary<string, Student> MDi2
        {
            get { return Di2; }
            set { Di2 = value; }
        }
        

        public static Student Metod (int val)
        {
            Student A = new Student ();
            A.MName += val;
            return A;
        }



        public TestCollections()
        {
            MLPerson = new List<Person> ();
            MStrings = new List<string> ();
            MDi1 = new Dictionary<Person, Student> ();
            MDi2 = new Dictionary<string, Student> ();
        }

        public TestCollections(int numb)
        {
            for(int i = 0; i < numb; i++)
            {
                MLPerson.Add(Metod(i).person);
                MStrings.Add(MLPerson[i].ToString());
                MDi1.Add(Metod(i).person, Metod (i));
                MDi2.Add(MLPerson[i].ToString(), Metod (i));
            }
        }



        public void TimeSearch(Person per, string str, Student std, ref TimeSpan o1, ref TimeSpan o2, 
                               ref TimeSpan o3, ref TimeSpan o4, ref TimeSpan o5, 
                               ref bool a, ref bool b, ref bool c, ref bool d, ref bool e)
        {
            var Secundomer = new Stopwatch();

            Secundomer.Start();
            a = MLPerson.Contains(per);
            Secundomer.Stop();
            o1 = Secundomer.Elapsed;


            Secundomer.Restart();
            b = MStrings.Contains(str);
            Secundomer.Stop();
            o2 = Secundomer.Elapsed;

           
            Secundomer.Restart();
            c = MDi1.ContainsKey(per);
            Secundomer.Stop();
            o3 = Secundomer.Elapsed;

           
            Secundomer.Restart();
            d = MDi2.ContainsKey(str);
            Secundomer.Stop();
            o4 = Secundomer.Elapsed;


            Secundomer.Restart();
            e = MDi1.ContainsValue(std);
            Secundomer.Stop();
            o5 = Secundomer.Elapsed;
        }
    }
}
