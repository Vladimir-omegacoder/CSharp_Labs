
using CLab_2;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace CLab3
{
    internal class StudentCollections<TKey>
    {
        public enum Action
        {
            Add,
            Remove,
            Property
        }



#pragma warning disable CS0693
        public delegate TKey KeySelector<TKey>(Student st);
#pragma warning restore CS0693


#pragma warning disable CS0693
        public delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
#pragma warning restore CS0693




        //Pole (field)
        public string MNameCollection { get; set; }

        private Dictionary<TKey, Student> _students;

        private KeySelector<TKey> _keySelector;




        //ctor
        public StudentCollections(KeySelector<TKey> keySelector)
        {
            _keySelector = keySelector;
            MNameCollection = string.Empty;
            _students = new Dictionary<TKey, Student>();
        }



        //Оброботчик для события изменения свойства
        private void Student_change_property(object source, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StudentsChanged?.Invoke(source, new StudentsChangedEventArgs<TKey>(this.MNameCollection, Action.Property, e.PropertyName, _keySelector((Student)source)));
        }





        //Add default two student
        public void AddDefaults()
        {
            int count = 2;
            for (int i = 0; i < count; i++)
            {
                Student student = new Student(new Person("Abobus_Cheshka", "Rzhaviy", new DateTime(1999, 01, 01)), Education.Nobody, i);
                _students.Add(_keySelector(student), student);

                student.PropertyChanged += Student_change_property;
                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(this.MNameCollection, Action.Add, "", _keySelector(student)));
            }
        }


        //Add many students
        public void AddStudent(params Student[] parameters)
        {
            foreach (var student in parameters)
            {
                _students.Add(_keySelector(student), student);

                student.PropertyChanged += Student_change_property;

                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(this.MNameCollection, Action.Add, "", _keySelector(student)));
            }
        }




        //Delete element
        public bool Remove(Student st)
        {

            TKey k = _keySelector(st);

            if (_students.ContainsKey(k))
            {
                _students.Remove(k);

                st.PropertyChanged -= Student_change_property;

                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(this.MNameCollection, Action.Remove, "", k));

                return true;
            }

            return false;

        }







        //Max GPA in collection
        public double Max_GPA
        {
            get
            {
                if (_students.Count == 0)
                {
                    return 0;
                }
                else
                {
                    var p = from student in _students.Values select student.GPA;
                    return p.Max();
                }
            }
        }


        //All student with educetion == value
        public IEnumerable<KeyValuePair<TKey, Student>> EducetionForm(Education value)
        {
            IEnumerable<KeyValuePair<TKey, Student>> p = from student in _students where student.Value.Meducation == value select student;

            return p;
        }


        
        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupBy_Educetion
        {
            get
            {
                var p = _students.GroupBy(p => p.Value.Meducation);
                return p;
            }
        }





        //Vivod
        public override string ToString()
        {
            string s = "\n";
            int i = 1;

            foreach (var student in _students) 
            { 
                s += $"\n{i}. {MNameCollection}\nKey: {student.Key}\nValue: {student.Value}\n\n"; 
            }

            return s;
        }


        public virtual string ToShortString()
        {
            string s = "\n";
            int i = 1, e = 0, t = 0;

            foreach (var student in _students)
            {
                s += $"\n{i}. {MNameCollection}\nKey: {student.Key}\nValue: {student.Value.ToShortString()}";

                e = student.Value.MExam.Count();
                t = student.Value.MTest.Count();

                s += $"Number of exams: {e}\n";
                s += $"Number of tests: {t}\n\n";
            }

            return s;
        }






        public event StudentsChangedHandler<TKey>? StudentsChanged;

    }
}
