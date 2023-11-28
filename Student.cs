using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace CLab2
{
    internal class Student : Person, IDateAndCopy, System.ComponentModel.INotifyPropertyChanged
    {

        //Плде должности
        private Education education;
        public Education Meducation
        {
            get { return education; }
            set 
            { 
                education = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Meducation)));
            }
        }


        //Поле группы
        private int group;
        public int Mgroup
        {
            get { return group; }
            set
            {
                if (value <= 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Error. Group number must be >1 and <100");
                }
                group = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mgroup)));
            }
        }


        //Списое экзаменов
        private List<Exam> Exams;
        public List<Exam> MExam
        {
            get { return Exams; }
            set { Exams = value; }
        }


        //Список тестов
        private List<Test> Tests;
        public List<Test> MTest
        {
            get { return Tests; }
            set { Tests = value; }
        }





        /////////////////////////////////////////////
        public event PropertyChangedEventHandler? PropertyChanged;
        /////////////////////////////////////////////




        public Student(Person pers, Education education, int group) : base(pers.MName, pers.MSurname,
                                                                           pers.MDateofBirth)
        {
            this.education = education;
            this.group = group;
            Exams = new List<Exam> { };
            Tests = new List<Test> { };
        }

        public Student()
        {
            education = new Education();
            group = 0;
            Exams = new List<Exam> { new Exam() };
            Tests = new List<Test> { new Test() };

        }



        public Person person
        {
            get
            { return new Person(MName, MSurname, MDateofBirth); }
            set
            {

                MName = value.MName;
                MSurname = value.MSurname;
                MDateofBirth = value.MDateofBirth;
            }
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Student))
            {
                return false;
            }
            Student person = (Student)obj;
            return Name == person.MName && Surname == person.MSurname && DateofBirth == person.MDateofBirth && 
                   person.GPA == person.GPA && MTest.SequenceEqual(person.MTest) && MExam.SequenceEqual(person.MExam);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }



        //Метод добавления экзаменоа
        public void AddExams(params Exam[] parameters)
        {
            foreach (var exam in parameters)
            {
                Exams.Add(exam);
            }
        }



        //Метод добавления тестов
        public void AddTests(params Test[] parameters)
        {
            foreach (var test in parameters)
            {
                Tests.Add(test);
            }
        }



        //Вычесление среднего балла
        public double GPA
        {
            get
            {
                double gpa = 0;
                foreach (var exam in Exams)
                {
                    gpa += exam.Grade;
                }
                return gpa / Exams.Count;
            }
        }











        public override string ToString()
        {
            string S = $"Student: {base.ToString()}\nGroup: {group}\nEducation: {education}\nExam:";
            foreach (var value in Exams)
            {
                S += value + "\n";
            }
            S += "Test: ";
            foreach (var value in Tests)
            {
                S += value + "\n";
            }
            return S;

        }

        public virtual new string ToShortString()
        {
            return $"Student: {base.ToShortString()}\nGroup: {group}\nEducation: {education}\nGPA: {GPA}";
        }



        public override object DeepCopy()
        {
            Student copy = new Student(person, education, group);
            foreach (var exam in Exams)
            {
                copy.Exams.Add((Exam)exam.DeepCopy());
            }
            foreach (var test in Tests)
            {
                copy.Tests.Add((Test)test.DeepCopy());
            }
            return copy;
        }



        public IEnumerable Numerator1()
        {
            foreach (var exam in Exams)
            {
                yield return exam;
            }

            foreach (var test in Tests)
            {
                yield return test;
            }
        }

        public IEnumerable Numerator2(int result)
        {
            foreach (var exam in Exams)
            {
                if (exam.Grade > result)
                {
                    yield return exam;
                }
            }
        }
    }
}
