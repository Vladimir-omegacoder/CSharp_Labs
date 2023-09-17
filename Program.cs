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

        public static void Vivod(object sender, StudentListHandlerEventArgs e)
        {
            if(sender is StudentCollections)
            {
               Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student(new Person("Name", "Surname", new DateTime (2005, 05, 12)), Education.Specialist, 3);
            //Console.WriteLine(student.ToString());

            StudentCollections studentCollections = new StudentCollections("Spisok");
            studentCollections.StudentsCountChanged += Vivod;
            studentCollections.AddDefaults();
            studentCollections.AddStudent(student);
            studentCollections.Remove(2);
            studentCollections[0] = student;

            //Console.WriteLine(studentCollections.Remove(5));

            //Console.WriteLine(studentCollections[5]);
        }
    }
}
