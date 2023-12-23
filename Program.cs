using Lab1;
using Lab4;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;





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

        GraduateStudentCollection students1 = new GraduateStudentCollection();
        students1.CollectionName = "Group 1";
        GraduateStudentCollection students2 = new GraduateStudentCollection();
        students2.CollectionName = "Group 2";


        TeamsJournal teamsJournal1 = new TeamsJournal();
        TeamsJournal teamsJournal2 = new TeamsJournal();


        students1.GraduateStudentInserted   += teamsJournal1.GraduateStudentCollectionExpanded;
        students1.GraduateStudentAdded      += teamsJournal1.GraduateStudentCollectionExpanded;

        students1.GraduateStudentInserted   += teamsJournal2.GraduateStudentCollectionExpanded;
        students2.GraduateStudentInserted   += teamsJournal2.GraduateStudentCollectionExpanded;


        students1.AddDefaults();
        students2.AddDefaults();


        Person person1 = new Person("Someone", "Sometwo", new DateTime(2002, 2, 2));
        GraduateStudent gr1 = new GraduateStudent("Madara", "Uchiha", new DateTime(10, 10, 10),
            person1, "Leader of the Uchiha clan", "Mangeku sharingan", FormOfStudy.FullTime, 4);
        gr1.Add_articles(new Article("Konoha village", "Fire country", new DateTime(1010, 1, 1)));
        gr1.NotesList.Add(new Notes("Ez", "Solo confernce", new DateTime(1420, 10, 10)));

        Person person2 = new Person("Joe", "Biden", new DateTime(1942, 11, 20));
        GraduateStudent gr2 = new GraduateStudent("Sussy", "Baka", new DateTime(2008, 8, 28),
            person2, "0 impacter", "Professional gaming", FormOfStudy.Distance, 3);
        gr2.Add_articles(new Article("Skill issue", "London", new DateTime(2020, 10, 10)),
            new Article("Team blaming", "Birmingham", new DateTime(2018, 9, 5)));
        gr2.NotesList.Add(new Notes("Skill issue, Too bad", "Noname tournament", new DateTime(2018, 10, 16)));


        students1.InsertAt(7, gr1);
        students2.InsertAt(3, gr1);

        students1.InsertAt(-7, gr2);
        students2.InsertAt(15, gr2);



        Console.WriteLine("------------ JOURNAL 1 ------------");
        Console.WriteLine(teamsJournal1);

        Console.WriteLine("\n");

        Console.WriteLine("------------ JOURNAL 2 ------------");
        Console.WriteLine(teamsJournal2);

    }

}