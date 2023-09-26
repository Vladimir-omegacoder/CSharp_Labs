using S1_CLab1;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CLab1
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
        static void Vvod(ref int n)
        {
            Console.WriteLine($"Enter please size: ");
            bool result1 = int.TryParse(Console.ReadLine(), out n);

            while (result1 == false)
            {
                Console.WriteLine("Incorrect value. Enter again");
                result1 = int.TryParse(Console.ReadLine(), out n);
            }
        }


        static void Main(string[] args)
        {
            Student student = new Student(new Person("Name", "Surname", new DateTime (2005, 05, 12)), Education.Specialist, 3);



            StudentCollections studentCollection_1 = new StudentCollections("Collection 1");

            studentCollection_1.AddStudent(new Student(new Person("Igor", "Zomich", new DateTime(2002, 03, 16)), Education.SecondEducation, 3));
            studentCollection_1.AddStudent(new Student(new Person("Vasyl", "Gordienko", new DateTime(2001, 07, 07)), Education.Specialist, 4));
            studentCollection_1.AddStudent(new Student(new Person("Gennady", "Komarov", new DateTime(2004, 12, 05)), Education.Bachelor, 1));



            StudentCollections studentCollection_2 = new StudentCollections("Collection 2");

            studentCollection_2.AddStudent(new Student(new Person("Catherine", "Bulka", new DateTime(2006, 10, 01)), Education.Bachelor, 4));
            studentCollection_2.AddStudent(new Student(new Person("Hanna", "Komarova", new DateTime(2003, 03, 08)), Education.SecondEducation, 2));
            studentCollection_2.AddStudent(new Student(new Person("Olga", "Movchan", new DateTime(2000, 06, 23)), Education.Specialist, 3));



            Journal journal_1 = new Journal();
            Journal journal_2 = new Journal();


            studentCollection_1.StudentsCountChanged += journal_1.Changed;
            studentCollection_1.StudentReferenceChanged += journal_1.Changed;

            studentCollection_1.StudentReferenceChanged += journal_2.Changed;
            studentCollection_2.StudentReferenceChanged += journal_2.Changed;



            studentCollection_1.AddStudent(student);
            studentCollection_2.AddStudent(student);

            studentCollection_1.Remove(1);
            studentCollection_2.Remove(1);

            studentCollection_1[2] = student;
            studentCollection_2[2] = student;


            Console.WriteLine("***************Journal 1***************\n");
            Console.WriteLine(journal_1.ToString());

            Console.WriteLine("\n\n");

            Console.WriteLine("***************Journal 2***************\n");
            Console.WriteLine(journal_2.ToString());

        }
    }
}
