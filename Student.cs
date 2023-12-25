using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.Mime.MediaTypeNames;



namespace CLab3
{
    ///
    [Serializable]
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











        //Копирование с помощю сереализации
        public override object DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter(); 

            bf.Serialize(stream, this);

            stream.Position = 0;

            Student copy = (Student)bf.Deserialize(stream);

            return copy;
        }



        //Созранение в файл с помощью сереалищации
        public bool Save(string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fstream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fstream, this);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        //Ввод из файла с помощью десереализации
        public bool Load(string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fstream = File.OpenRead(filename))
                {
                    Student st = (Student)bf.Deserialize(fstream);

                    this.education = st.education;
                    this.Mgroup = st.Mgroup;
                    this.person = st.person;

                    foreach (var exam in st.MExam)
                    {
                        this.MExam.Add((Exam)exam.DeepCopy());
                    }
                    foreach (var test in st.MTest)
                    {
                        this.MTest.Add((Test)test.DeepCopy());
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }



        //Добавление экзамена с консоли
        public bool AddFromConsole()
        {

            try
            {
                Console.WriteLine("Введiть нвзву предмета, оцiтка, дата(рiк.мiсяць.число) через кому\n");

                string[] tok = Console.ReadLine().Split(", ");

                Exam ex = new Exam();

                ex.ExamName = tok[0];
                ex.Grade = int.Parse(tok[1]);

                string[] tok_D = tok[2].Split(".");

                DateTime d = new DateTime(int.Parse(tok_D[0]), int.Parse(tok_D[1]), int.Parse(tok_D[2]));

                ex.ExamDate = d;

                this.AddExams(ex);

                return true;
            }

            catch (Exception)
            {
                Console.WriteLine("При введеннi даних винекла помилка");
                return false;
            }

        }




        public static bool Save(string filename, Student obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fstream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fstream, obj);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public static bool Load(string filename, Student obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fstream = File.OpenRead(filename))
                {
                    obj = (Student)bf.Deserialize(fstream);
                }

                return true;
            }

            catch (Exception)
            {
                return false;
            }
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
