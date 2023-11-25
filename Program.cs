using CSharp_Lab2;
using Lab1;
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

    static string KeySelector(GraduateStudent student)
    {
        return student.Surname;
    }


    private static void Main(string[] args)
    {

        GraduateStudentCollection<string> group_1 = new GraduateStudentCollection<string>(KeySelector);
        group_1.CollectionName = "GROUP_1";
        GraduateStudentCollection<string> group_2 = new GraduateStudentCollection<string>(KeySelector);
        group_2.CollectionName = "GROUP_2";

        TeamsJournal journal = new TeamsJournal();

        group_1.GraduateStudentsChanged += journal.GraduateStudentsChanged;
        group_2.GraduateStudentsChanged += journal.GraduateStudentsChanged;



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



        group_1.AddDefaults();

        group_1.AddGraduateStudent(gr1);
        gr1.FormOfstudy = FormOfStudy.Distance;
        gr1.Name = "I have a new name!!!";

        group_1.AddGraduateStudent(gr2);
        gr2.FormOfstudy = FormOfStudy.PartTime;



        group_1.Remove(new GraduateStudent($"Name_{1}", $"Surname_{1}",
            new DateTime(), new Person(), "", "", FormOfStudy.FullTime, 1));

        group_1.Remove(gr2);
        gr2.FormOfstudy = FormOfStudy.FullTime;



        group_1.Replace(gr1,
            new GraduateStudent($"Name_{11}", gr1.Surname,
            new DateTime(), new Person(), "", "", FormOfStudy.FullTime, 4));
        gr1.FormOfstudy = FormOfStudy.PartTime;




        Console.WriteLine(journal);



        group_1.Replace(new GraduateStudent($"Name_{11}", gr1.Surname,
            new DateTime(), new Person(), "", "", FormOfStudy.FullTime, 4), gr1);

        Console.WriteLine("------------ MAX_YEAR_OF_STUDY ------------");

        Console.WriteLine(group_1.MaxYearOfStudy);

        Console.WriteLine("-------------------------------------------");



        Console.WriteLine("------------ TUTION_FORM ------------");

        foreach (var i in group_1.TuitionForm(FormOfStudy.PartTime))
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("-------------------------------------");



        Console.WriteLine("------------ GROUP_BY ------------");

        foreach (var grouping in group_1.GroupByFormOfStudy)
        {
            foreach (var i in grouping)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("----------------------------------");

    }

}