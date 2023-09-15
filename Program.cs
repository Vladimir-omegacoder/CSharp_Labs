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
            //Student student = new Student();
            //Console.WriteLine(student.ToString());

            StudentCollections studentCollections = new StudentCollections();
            studentCollections.AddDefaults();

            Console.WriteLine(studentCollections.Remove(5));
        }
    }
}
