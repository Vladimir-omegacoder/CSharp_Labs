using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace Lab4
{

    [Serializable]
    internal class GraduateStudent : Person, IDateAndCopy
    {

        private string             _position;

        private Person             _supervisor;

        private string             _specialization;

        private FormOfStudy        _formOfStudy;

        private int                _yearOfStudy;

        private List<Article>      _articles;

        private List<Notes>        _notes;



        public Person           Supervisor
        { 
            get { return _supervisor; }      
            set { _supervisor = value; } 
        }

        public string           Specialization
        { 
            get { return _specialization; }  
            set { _specialization = value; } 
        }

        public FormOfStudy      FormOfstudy
        { 
            get { return _formOfStudy; }     
            set { _formOfStudy = value; } 
        }

        public int              YearOfStudy
        { 
            get { return _yearOfStudy; }     
            set 
            {
                if(value <=0 || value > 4)
                {
                    throw new ArgumentException("Year of study can only be >0 and <=4");
                }
                _yearOfStudy = value;
            }
        }

        public string           Position
        { 
            get { return _position; }        
            set { _position = value; } 
        }

        public Person           GsPerson
        {
            get
            {
                return new Person(Name, Surname, BirthDate);
            }

            set
            {
                Name =      value.Name;
                Surname =   value.Surname;
                BirthDate = value.BirthDate;
            }
        }

        public Article?         NewestArticle
        {
            get
            {

                if (Articles.Count == 0)
                {
                    return null;
                }

                Article article = Articles[0];

                for (int i = 0; i < Articles.Count; ++i)
                {
                    if (Articles[i].PublDate > article.PublDate)
                    {
                        article = Articles[i];
                    }
                }

                return article;

            }
        }

        public List<Notes>      NotesList
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public List<Article>    Articles 
        { 
            get { return _articles; }
            set { _articles = value; }
        }


#pragma warning disable CS8618
        public GraduateStudent(string name, string surname, 
            DateTime birthDate, Person supervisor, string position,
            string specialization, FormOfStudy formOfStudy, int yearOfStudy) : 
            base(name, surname, birthDate)
#pragma warning restore CS8618
        {
            Supervisor =        supervisor;
            Position =          position;
            Specialization =    specialization;
            FormOfstudy =       formOfStudy;
            YearOfStudy =       yearOfStudy;
            Articles =          new List<Article>();
            NotesList =         new List<Notes>();
        }

#pragma warning disable CS8618
        public GraduateStudent()
#pragma warning restore CS8618
        {
            Supervisor =        new Person();
            Position =          "";
            Specialization =    "";
            FormOfstudy =       FormOfStudy.FullTime;
            YearOfStudy =       1;
            Articles =          new List<Article>();
            NotesList =         new List<Notes>();
        }



        public override GraduateStudent DeepCopy()
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using MemoryStream memoryStream = new MemoryStream();
            soapFormatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (GraduateStudent)soapFormatter.Deserialize(memoryStream);
        }

        public bool Save(string filename)
        {

            SoapFormatter soapFormatter = new SoapFormatter();
            FileStream? fstream = null;

            try
            {
                fstream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                soapFormatter.Serialize(fstream, this);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                fstream?.Close();
            }

            return false;

        }

        public bool Load(string filename)
        {

            SoapFormatter soapFormatter = new SoapFormatter();
            FileStream? fstream = null;

            try
            {

                fstream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                GraduateStudent? temp = (GraduateStudent?)soapFormatter.Deserialize(fstream);

                if (temp == null)
                {
                    return false;
                }

                Name = temp.Name;
                Surname = temp.Surname;
                BirthDate = temp.BirthDate;
                Supervisor = temp.Supervisor;
                Position = temp.Position;
                Specialization = temp.Specialization;
                FormOfstudy = temp.FormOfstudy;
                YearOfStudy = temp.YearOfStudy;
                Articles = temp.Articles;
                NotesList = temp.NotesList;

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { 
                fstream?.Close();
            }

            return false;

        }



        public static bool Save(string filename, GraduateStudent student)
        {
            return student.Save(filename);
        }

        public static bool Load(string filename, GraduateStudent student)
        {
            return student.Load(filename);
        }



        public bool AddFromConsole()
        {

            Console.WriteLine("Enter article attributes: *Ttile*, *Publishing place*, *Publishing time*.\n" +
                "Use \',\' as delimeter.");

            string[]? input = Console.ReadLine()?.Split(",");
            if (input == null || input.Length < 0)
            {
                Console.WriteLine("Wrong input\n");
                return false;
            }

            Article article = new Article();
            article.Title = input[0];
            article.PublPlace = input[1];
            DateTime temp;
            if (!DateTime.TryParseExact(input[2], "d", System.Globalization.CultureInfo.CurrentUICulture,
                System.Globalization.DateTimeStyles.None, out temp))
            {
                Console.WriteLine("Wrong input\n");
                return false;
            }
            article.PublDate = temp;

            Articles.Add(article);

            return true;

        }



        public string FOS_ToString(FormOfStudy form)
        {
            switch (form)
            {
                case FormOfStudy.FullTime:
                    return "Fulltime";
                case FormOfStudy.PartTime:
                    return "Parttime";
                case FormOfStudy.Distance:
                    return "Distance";
                default:
                    return "";
            }
        }

        public void Add_articles(params Article[] articles)
        {
            Articles.AddRange(articles);
        }


        
        public override string ToString()
        {
            string graduate_info =          "Graduate: " +          base.ToString() +               '\n';
            string supervisor_info =        "Supervisor: " +        Supervisor.ToString() +         '\n';
            string speciality_info =        "Specialization: " +    Specialization.ToString() +     '\n';
            string form_of_study_info =     "Form of study: " +     FOS_ToString(FormOfstudy) +     '\n';
            string year_of_study_info =     "Year of study: " +     YearOfStudy.ToString() +        '\n';

            string articles_info = "Articles:\n";
            for (int i = 0; i < Articles.Count; ++i)
            {
                articles_info += Articles[i].ToString() + '\n';
            }

            string notes_info = "Notes:\n";
            for (int i = 0; i < NotesList.Count; ++i)
            {
                notes_info += NotesList[i].ToString() + '\n';
            }

            return graduate_info + supervisor_info + speciality_info + form_of_study_info + year_of_study_info + articles_info + notes_info;
        }

        public new virtual string ToShortString()
        { 
            string graduate_info =          "Graduate: " +          base.ToString() +               '\n';
            string supervisor_info =        "Supervisor: " +        Supervisor.ToString() +         '\n';
            string speciality_info =        "Specialization: " +    Specialization.ToString() +     '\n';
            string form_of_study_info =     "Form of study: " +     FOS_ToString(FormOfstudy) +     '\n';
            string year_of_study_info =     "Year of study: " +     YearOfStudy.ToString() +        '\n';
            string articles_info =          $"Articles count: {Articles.Count}\n";
            string notes_info =             $"Notes count: {NotesList.Count}\n";

            return graduate_info + supervisor_info + speciality_info + form_of_study_info + year_of_study_info + articles_info + notes_info;
        }

        public IEnumerable<Article> GetLastYearsArtciles(int years)
        {
            foreach(var article in Articles)
            {

                if((DateTime.Now - article.PublDate).Days / 365 <= years)
                {
                    yield return article;
                }

            }
        }

        public IEnumerable<object> GetArticlesNotes() 
        {
            foreach (var article in Articles)
            {
                yield return article;
            }
            foreach (var note in NotesList)
            {
                yield return note;
            }
        }

        public override bool Equals(object? obj)
        {

            if(obj == null)
            {
                return false;
            }

            if(obj.GetType() != typeof(GraduateStudent))
            {
                return false;
            }

            GraduateStudent t = (GraduateStudent)obj;

            if(t.Name != Name || t.Surname != Surname || t.BirthDate != BirthDate)
            {
                return false;
            }

            if(t.Position != Position || t.Specialization != Specialization || t.YearOfStudy != YearOfStudy) 
            {
                return false;
            }

            if(t.FormOfstudy != FormOfstudy || t.Supervisor != Supervisor) 
            {
                return false;
            }

            if (!t.Articles.SequenceEqual(Articles)) 
            {
                return false;
            }

            if (!t.NotesList.SequenceEqual(NotesList))
            {
                return false;
            }

            return true;

        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

    }

}
