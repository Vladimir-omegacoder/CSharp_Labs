using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{

    internal class TestCollections
    {

        private List<Person>                            _personList;
        private List<string>                            _strList;
        private Dictionary<Person, GraduateStudent>     _personGsDict;
        private Dictionary<string, GraduateStudent>     _strGsDict;



        public TestCollections(int count)
        { 
            _personList =       new List<Person>(count);
            _personGsDict =     new Dictionary<Person, GraduateStudent>(count);

            _strList =          new List<string>(count);
            _strGsDict =        new Dictionary<string, GraduateStudent>(count);

            for (int i = 0; i < count; ++i)
            {
                _personList.Add(CreateElement(i).GsPerson);
                _personGsDict.Add(CreateElement(i).GsPerson, CreateElement(i));

                _strList.Add(CreateElement(i).GsPerson.ToString());
                _strGsDict.Add(CreateElement(i).GsPerson.ToString(), CreateElement(i));
            }
        }



        public static GraduateStudent CreateElement(int id)
        {
            GraduateStudent student = new GraduateStudent();
            student.Name += id.ToString();
            student.Surname += id.ToString();

            return student;
        }

        public bool ListContains(Person element, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            bool result = _personList.Contains(element);
            time.Stop();
            return result;
        }

        public bool ListContains(string element, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            bool result = _strList.Contains(element);
            time.Stop();
            return result;
        }

        public bool DictContainsKey(Person key, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            bool result = _personGsDict.ContainsKey(key);
            time.Stop();
            return result;
        }

        public bool DictContainsKey(string key, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            bool result = _strGsDict.ContainsKey(key);
            time.Stop();
            return result;
        }

        public bool DictContainsValue(GraduateStudent value, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            bool result = _personGsDict.ContainsValue(value);
            time.Stop();
            return result;
        }

    }

}
