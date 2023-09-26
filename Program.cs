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
            //Console.WriteLine(student.ToString());


            //studentCollections.StudentsCountChanged += Vivod;
            //studentCollections.AddDefaults();

            StudentCollections studentCollections = new StudentCollections("Spisok");

            studentCollections.AddStudent(new Student(new Person("Igor", "Zomich", new DateTime(2002, 03, 16)), Education.SecondEducation, 3));
            studentCollections.AddStudent(new Student(new Person("Vasyl", "Gordienko", new DateTime(2001, 07, 07)), Education.Specialist, 4));
            studentCollections.AddStudent(new Student(new Person("Gennady", "Komarov", new DateTime(2004, 12, 05)), Education.Bachelor, 1));


            studentCollections.Remove(2);
            studentCollections[0] = student;

            //Console.WriteLine(studentCollections.Remove(5));

            //Console.WriteLine(studentCollections[5]);
        }
    }
}
