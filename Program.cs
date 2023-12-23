using Lab1;
using Lab4;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Soap;





enum FormOfStudy
{

    FullTime,
    PartTime,
    Distance,

}





internal class Program
{

    private static void Main(string[] args)
    {

        Person person1 = new Person("Someone", "Sometwo", new DateTime(2002, 2, 2));
        GraduateStudent gr1 = new GraduateStudent("Madara", "Uchiha", new DateTime(10, 10, 10),
            person1, "Leader of the Uchiha clan", "Mangeku sharingan", FormOfStudy.FullTime, 4);
        gr1.Add_articles(new Article("Konoha village", "Fire country", new DateTime(1010, 1, 1)));
        gr1.Add_articles(new Article("Who asked?", "Somewhere", new DateTime(2023, 9, 10)));
        gr1.NotesList.Add(new Notes("Ez", "Solo confernce", new DateTime(1420, 10, 10)));



        GraduateStudent gs_copy = gr1.DeepCopy();

        Console.WriteLine("---------- ORIGINAL ----------\n");
        Console.WriteLine(gr1);
        Console.WriteLine("------------------------------");

        Console.WriteLine("\n\n");

        Console.WriteLine("---------- COPY ----------\n");
        Console.WriteLine(gs_copy);
        Console.WriteLine("------------------------------\n\n");



        string? filename = null;
        while (true)
        {
            Console.Write("Enter filename: ");
            filename = Console.ReadLine();
            if (filename == null)
            {
                Console.WriteLine("Try entering other name.");
                continue;
            }
            break;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("File with such name doesn't exist. Creating a new one...");
            File.Create(filename).Close();
        }
        else
        {
            Console.WriteLine("File exists, loading the data...");
            if (gr1.Load(filename))
            {
                Console.WriteLine("Data loaded successfully.");
            }
            else
            {
                Console.WriteLine("Failed to load the data.");
            }
        }

        Console.WriteLine("---------- OBJECT CURRENT STATE ----------\n");
        Console.WriteLine(gr1);
        Console.WriteLine("------------------------------\n\n");



        gr1.AddFromConsole();
        Console.WriteLine("Saving the data...");
        if (gr1.Save(filename))
        {
            Console.WriteLine("Data saved successfully.");
        }
        else
        {
            Console.WriteLine("Failed to save the data.");
        }

        Console.WriteLine("---------- OBJECT CURRENT STATEE ----------\n");
        Console.WriteLine(gr1);
        Console.WriteLine("------------------------------\n\n");



        Console.WriteLine("Loading the data...");
        if (GraduateStudent.Load(filename, gr1))
        {
            Console.WriteLine("Data loaded successfully.");
        }
        else
        {
            Console.WriteLine("Failed to load the data.");
        }
        gr1.AddFromConsole();
        Console.WriteLine("Saving the data...");
        if (GraduateStudent.Save(filename, gr1))
        {
            Console.WriteLine("Data saved successfully.");
        }
        else
        {
            Console.WriteLine("Failed to save the data.");
        }

        Console.WriteLine("---------- OBJECT CURRENT STATEE ----------\n");
        Console.WriteLine(gr1);
        Console.WriteLine("------------------------------\n\n");

    }

}