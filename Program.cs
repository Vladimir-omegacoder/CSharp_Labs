using Lab4;
using System.Diagnostics;





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

        Console.WriteLine("--------------Task 1--------------\n\n");

        GraduateStudentCollection students = new GraduateStudentCollection();


        Person person1 = new Person("Joe", "Biden", new DateTime(1942, 11, 20));
        GraduateStudent gr1 = new GraduateStudent("Sussy", "Baka", new DateTime(2008, 8, 28),
            person1, "0 impacter", "Professional gaming", FormOfStudy.Distance, 3);
        gr1.Add_articles(new Article("Skill issue", "London", new DateTime(2020, 10, 10)),
            new Article("Team blaming", "Birmingham", new DateTime(2018, 9, 5)));
        gr1.NotesList.Add(new Notes("Skill issue, Too bad", "Noname tournament", new DateTime(2018, 10, 16)));

        Person person2 = new Person("Bosch", "Dishwaher", new DateTime(1999, 12, 12));
        GraduateStudent gr2 = new GraduateStudent("Aboba", "Kent", new DateTime(2006, 4, 14),
            person2, "Wasshhhhh!!!", "Cleaning", FormOfStudy.FullTime, 4);

        Person person3 = new Person("Someone", "Sometwo", new DateTime(2002, 2, 2));
        GraduateStudent gr3 = new GraduateStudent("Madara", "Uchiha", new DateTime(10, 10, 10),
            person3, "Leader of the Uchiha clan", "Mangeku sharingan", FormOfStudy.FullTime, 4);
        gr3.Add_articles(new Article("Konoha village", "Fire country", new DateTime(1010, 1, 1)));
        gr3.NotesList.Add(new Notes("Ez", "Solo confernce", new DateTime(1420, 10, 10)));

        Person person4 = new Person("Billy", "Brown", new DateTime(1989, 5, 25));
        GraduateStudent gr4 = new GraduateStudent("Carl", "Clown", new DateTime(2000, 2, 28),
            person4, "Nothing manager", "Finance managing", FormOfStudy.PartTime, 2);

        Person person5 = new Person("Joe", "Biden", new DateTime(1942, 11, 20));
        GraduateStudent gr5 = new GraduateStudent("Sussy", "Baka", new DateTime(2008, 8, 28),
            person5, "0 impacter", "Professional gaming", FormOfStudy.Distance, 3);
        gr5.Add_articles(new Article("Skill issue", "London", new DateTime(2020, 10, 10)),
            new Article("Team blaming", "Birmingham", new DateTime(2018, 9, 5)));
        gr5.NotesList.Add(new Notes("Skill issue, Too bad", "Noname tournament", new DateTime(2018, 10, 16)));


        students.AddGraduateStudents(gr1, gr2, gr3, gr4, gr5);

        Console.WriteLine(students);

        Console.WriteLine("----------------------------------\n\n");



        Console.WriteLine("--------------Task 2--------------\n\n");

        Console.WriteLine("\t\t\t|||Sorted by surname|||");
        students.SortBySurname();
        Console.WriteLine(students.ToShortString());

        Console.WriteLine("\t\t\t|||Sorted by date of birth|||");
        students.SortByBirthDate();
        Console.WriteLine(students.ToShortString());

        Console.WriteLine("\t\t\t|||Sorted by year of study|||");
        students.SortByYearOfStudy();
        Console.WriteLine(students.ToShortString());

        Console.WriteLine("----------------------------------\n\n");



        Console.WriteLine("--------------Task 3--------------\n\n");

        int size = 30;

        while (true)
        {
            Console.Write("Enter size: ");
            if(int.TryParse(Console.ReadLine(), out size))
            {
                if(size > 0) 
                {
                    break;
                }
            }
            Console.WriteLine("You have to enter a positive integer.");
        }

        TestCollections testCollections = new TestCollections(size);
        Stopwatch time;
        bool found = false;



        // Person list 
        {

            Console.WriteLine("| Person list |");

            found = testCollections.ListContains(TestCollections.CreateElement(size - size).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size / 2 - 1).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size / 2 - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size - 1).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

        }



        // String list 
        {

            Console.WriteLine("| String list |");

            found = testCollections.ListContains(TestCollections.CreateElement(size - size).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size / 2 - 1).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size / 2 - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size - 1).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.ListContains(TestCollections.CreateElement(size).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

        }



        // Person key dict 
        {

            Console.WriteLine("| Person key dict |");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size - size).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size / 2 - 1).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size / 2 - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size - 1).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size).GsPerson, out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

        }



        // String key dict 
        {

            Console.WriteLine("| String key dict |");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size - size).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size / 2 - 1).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size / 2 - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size - 1).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - 1).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsKey(TestCollections.CreateElement(size).GsPerson.ToString(), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size).GsPerson}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

        }



        // GraduateStudent value dict 
        {

            Console.WriteLine("| GraduateStudent value dict |");

            found = testCollections.DictContainsValue(TestCollections.CreateElement(size - size), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - size)}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsValue(TestCollections.CreateElement(size / 2 - 1), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size / 2 - 1)}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsValue(TestCollections.CreateElement(size - 1), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size - 1)}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

            found = testCollections.DictContainsValue(TestCollections.CreateElement(size), out time);
            Console.WriteLine($"Results for {TestCollections.CreateElement(size)}");
            Console.WriteLine($"Time: {time.Elapsed}; found: {found}");

        }



        Console.WriteLine("----------------------------------\n\n");

    }

}