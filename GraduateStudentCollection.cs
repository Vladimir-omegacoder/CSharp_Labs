using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    internal class GraduateStudentCollection
    {

        private List<GraduateStudent>   _students;

        public string                   CollectionName { get; set; }

        public GraduateStudent          this[int index]
        {
            get { return _students[index]; }
            set { _students[index] = value; }
        }



        public delegate void GraduateStudentListHandler(object source, GraduateStudentListHandlerEventArgs args);

        public event GraduateStudentListHandler? GraduateStudentAdded;

        public event GraduateStudentListHandler? GraduateStudentInserted;



        public GraduateStudentCollection()
        { 
            _students = new List<GraduateStudent>();
            CollectionName = "";
            GraduateStudentAdded = null;
            GraduateStudentInserted = null;
        }



        public void AddDefaults()
        {
            int count = 10;
            _students.Capacity += count;

            for (int i = 0; i < count; ++i)
            {
                _students.Add(new GraduateStudent());
            }

            GraduateStudentAdded?.Invoke(this, new GraduateStudentListHandlerEventArgs(
                CollectionName, "10 default objects have been added", _students.Count));
        }

        public void AddGraduateStudents(params GraduateStudent[] students)
        {
            _students.AddRange(students);

            GraduateStudentAdded?.Invoke(this, new GraduateStudentListHandlerEventArgs(
                CollectionName, $"{students.Length} object(s) has(have) been added", _students.Count));
        }

        public void InsertAt(int j, GraduateStudent gs)
        {
            if(j < 0 || j > _students.Count - 1) 
            {
                _students.Add(gs);
                GraduateStudentAdded?.Invoke(this, new GraduateStudentListHandlerEventArgs(
                CollectionName, $"Object has been added", _students.Count));
            }
            else
            {
                _students.Insert(j, gs);
                GraduateStudentInserted?.Invoke(this, new GraduateStudentListHandlerEventArgs(
                CollectionName, $"Object has been inserted", j));
            }
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
