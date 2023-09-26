
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CLab1
{
    internal class StudentCollections : IComparer<Student>
    {
        private List<Student> CStudent;
        public List<Student> MCStudent
        {
            get { return CStudent; }
            set { CStudent = value; }
        }

        public string MNameCollection { get; set; }



        public StudentCollections()
        {
            MNameCollection = string.Empty;
            CStudent = new List<Student>();
        }


        public StudentCollections(string name)
        {
            MNameCollection = name;
            CStudent = new List<Student>();
        }



        public int Compare(Student? x, Student? y)
        {
            if(x is Student && y is Student)
            {
                if ( x is null || y is null)
                {
                    throw new ArgumentException("No data!");

                }
                else
                {
                    return x.GPA.CompareTo(y.GPA);
                }
            }

            throw new ArgumentException("Error. Wrong type!");
        }


        public void AddDefaults()
        {
            int count = 2;
            for (int i = 0; i < count; i++)
            {
                CStudent.Add(new Student());

                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(this.MNameCollection, "Add element", this.MCStudent.Last()));
            }
        }

        public void AddStudent(params Student[] parameters)
        {
            foreach (var student in parameters)
            {
                CStudent.Add(student);

                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(this.MNameCollection, "Add element", this.MCStudent.Last()));

            }
        }


        public bool Remove(int j)
        {

            try
            {
                Student student = CStudent[j];
                MCStudent.RemoveAt(j);

                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(this.MNameCollection, "Delete element", student));

                return true;
            }

            catch (ArgumentOutOfRangeException)
            { return false; }

        }



        public Student this[int index]
        {
            get => MCStudent[index];

            set
            {
                MCStudent[index] = value;

                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(this.MNameCollection, "Element changed", MCStudent[index]));
            }
        }



        public override string ToString()
        {
            string s = "\n";

            for(int i = 0; i < CStudent.Count(); i++)
            {
                s += $"\n{i + 1}. {CStudent[i]}\nGPA: {CStudent[i].GPA}\n";
            }
            return s;
        }

        public virtual string ToShortString()
        {
            string s = "\n";
            for (int i = 0; i < CStudent.Count(); i++)
            {
                s += $"{i + 1}. {CStudent[i].ToShortString()}\n";

                int e = CStudent[i].MExam.Count();
                int t = CStudent[i].MTest.Count();

                s += $"Number of exams: {e}\n";
                s += $"Number of tests: {t}\n";
            }
            return s;
        }




        public void SortSurN()
        {
            CStudent.Sort();
        }

        public void SortDateB()
        {
            CStudent.Sort(new Student());
        }

        public void SortGPA()
        {
            CStudent.Sort(new StudentCollections());
        }



        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);



        public event StudentListHandler? StudentsCountChanged;
        public event StudentListHandler? StudentReferenceChanged;
    }
}
