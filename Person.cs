using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab1
{
    internal class Person: IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string Name;
        public string MName
        {
            get { return Name; }
            set { Name = value; }
        }


        protected string Surname;
        public string MSurname
        {
            get { return Surname; }
            set { Surname = value; }
        }


        protected DateTime DateofBirth;
        public DateTime MDateofBirth
        {
            get { return DateofBirth; }
            set { DateofBirth = value; }
        }



        public Person()
        {
            Name = string.Empty;
            Surname = string.Empty;
            DateofBirth = new DateTime();
        }
        public Person(string name, string surname, DateTime dateofbirth)
        {
            MName = name;
            MSurname = surname;
            MDateofBirth = dateofbirth;
        }



        public override string ToString()
        {
            return $"Name - {Name}   Surname - {Surname}   Date of Birth - {DateofBirth.ToString("dd MMMM yyyy")}";
        }

        public virtual string ToShortString()
        {
            return $"Name - {Name}    Surname - {Surname}";
        }



        public int NewYear
        {
            get { return DateofBirth.Year; }

            set { DateofBirth = DateofBirth.AddYears(value - DateofBirth.Year); }
        }

        public DateTime Date { get; set; }


        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Person) || (object)obj == null)
            {
                return false;
            }
            Person person = (Person)obj;
            return Name == person.Name && Surname == person.Surname && DateofBirth == person.DateofBirth;
        }


        public static bool operator == (Person lp, Person rp)
        {
            if(Object.ReferenceEquals(lp, rp))
            {
                return true;
            }

            if((object)lp == null || (object)rp == null)
            {
                return false;
            }
            return lp.Equals(rp);
        }           

        public static bool operator != (Person lp, Person rp)
        {
            return !(lp == rp);
        }


        public virtual object DeepCopy()
        {
            Person copy = new Person(Name, Surname, DateofBirth);
            return copy;
        }



        public int CompareTo(object? obj)
        {
            if (obj != null && obj is Person person)
            {
                return MSurname.CompareTo(person.MSurname);
            }
            else 
            {
                throw new ArgumentException("Error. Wrong type or No data!");
            }
        }

        public int Compare(Person? x, Person? y)
        {
            if (x is Person && y is Person)
            {
                if (x is null || y is null)
                {
                    throw new ArgumentException("No data!");

                }
                else
                {
                    return x.MDateofBirth.CompareTo(y.MDateofBirth);
                }
            }

            throw new ArgumentException("Error. Wrong type!");
        }
    }
}
