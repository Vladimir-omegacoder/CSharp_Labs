using S1_CLab2;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CLab2
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
    enum Education
    {
        Nobody,
        Specialist,
        Bachelor,
        SecondEducation
    }



    class Program
    {
        static string Selector_Key(Student st)
        {
            return st.MName;
        }




        static void Main(string[] args)
        {
            Student student = new Student(new Person("Name", "Surname", new DateTime(2005, 05, 12)), Education.Specialist, 3);
            student.AddExams(new Exam("History", 63, new DateTime(2023, 03, 28)),
               new Exam("C#", 34, new DateTime(2023, 03, 28)));
            student.AddTests(new Test("Math", true));



            Student student1 = new Student(new Person("Igor", "Zomich", new DateTime(2002, 03, 16)), Education.SecondEducation, 3);
            student1.AddExams(new Exam("C#", 34, new DateTime(2023, 03, 28)),
            new Exam("C++", 93, new DateTime(2023, 03, 28)));

            Student student2 = new Student(new Person("Vasyl", "Gordienko", new DateTime(2001, 07, 07)), Education.Bachelor, 4);

            Student student3 = new Student(new Person("Gennady", "Komarov", new DateTime(2004, 12, 05)), Education.Specialist, 1);
            student3.AddExams(new Exam("History", 66, new DateTime(2023, 03, 28)),
            new Exam("Philosophy", 16, new DateTime(2023, 03, 25)));



            Student student4 = new Student(new Person("Catherine", "Bulka", new DateTime(2006, 10, 01)), Education.Bachelor, 4);
            Student student5 = new Student(new Person("Hanna", "Komarova", new DateTime(2003, 03, 08)), Education.SecondEducation, 2);
            Student student6 = new Student(new Person("Olga", "Movchan", new DateTime(2000, 06, 23)), Education.Specialist, 3);







            StudentCollections<string> studentCollection_1 = new StudentCollections<string>(Selector_Key);

            studentCollection_1.MNameCollection = "Collection 1";

            studentCollection_1.AddStudent(student1);
            studentCollection_1.AddStudent(student2);
            studentCollection_1.AddStudent(student3);



            StudentCollections<string> studentCollection_2 = new StudentCollections<string>(Selector_Key);

            studentCollection_2.MNameCollection = "Collection 2";

            studentCollection_2.AddStudent(student4);
            studentCollection_2.AddStudent(student5);
            studentCollection_2.AddStudent(student6);



            Journal journal_1 = new Journal();


            studentCollection_1.StudentsChanged += journal_1.Changed;

            studentCollection_2.StudentsChanged += journal_1.Changed;


            studentCollection_1.AddStudent(student);
            studentCollection_2.AddStudent(student);


            student2.Mgroup = 8;
            student4.Meducation = Education.Nobody;


            studentCollection_1.Remove(student2);
            studentCollection_2.Remove(student4);


            student2.Mgroup = 87;
            student4.Meducation = Education.Bachelor;


            Console.WriteLine("-------------------------------------------------------------------\n");

            Console.WriteLine("***************Journal 1***************\n");
            Console.WriteLine(journal_1.ToString());

            Console.WriteLine("\n-------------------------------------------------------------------");

            Console.WriteLine("\n\n");





            Console.WriteLine("-------------------------------------------------------------------\n");

            Console.WriteLine("Max GPA in Collection_1: ");
            Console.WriteLine(studentCollection_1.Max_GPA);

            Console.WriteLine("\n-------------------------------------------------------------------");

            Console.WriteLine("\n\n");





            Console.WriteLine("-------------------------------------------------------------------\n");

            Console.WriteLine("Specialist in Collection_1: \n");

            foreach (var i in studentCollection_1.EducetionForm(Education.Specialist))
            {               
                Console.WriteLine($"{i}\n");
            }

            Console.WriteLine("\n-------------------------------------------------------------------");

            Console.WriteLine("\n\n");






            Console.WriteLine("-------------------------------------------------------------------\n");

            foreach (var i in studentCollection_1.GroupBy_Educetion)
            {
                foreach (var j in i)
                {
                    Console.WriteLine($"{j}\n");
                }
            }
            Console.WriteLine("\n-------------------------------------------------------------------");

            Console.WriteLine("\n\n");

        }
    }
}

