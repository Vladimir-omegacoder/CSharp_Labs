using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    internal class GraduateStudentCollection
    {

        private List<GraduateStudent> _students;



        public GraduateStudentCollection()
        { 
            _students = new List<GraduateStudent>();
        }



        public void AddDefaults()
        {
            int count = 10;
            _students.Capacity += count;

            for (int i = 0; i < count; ++i)
            {
                _students.Add(new GraduateStudent());
            }
        }

        public void AddGraduateStudents(params GraduateStudent[] students)
        {
            _students.AddRange(students);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (GraduateStudent student in _students) 
            {
                sb.Append(student.ToString() + "-----------------------------------\n");
            }

            return sb.ToString();
        }

        public string ToShortString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (GraduateStudent student in _students)
            {
                sb.Append(student.ToShortString() + "-----------------------------------\n");
            }

            return sb.ToString();
        }

        public void SortBySurname()
        {
            _students.Sort();
        }

        public void SortByYearOfStudy()
        {
            _students.Sort(new GraduateStudentComparer());
        }

        public void SortByBirthDate()
        {
            _students.Sort(new Person());
        }

    }

}
