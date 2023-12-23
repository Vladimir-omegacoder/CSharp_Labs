using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    [Serializable]
    internal class Person : IDateAndCopy, IComparable, IComparer<Person>
    {

        protected string        _name;
        protected string        _surname;
        protected DateTime      _birthDate;



        public string       Name
        {
            get { return _name; }
            set { _name = value ?? throw new ArgumentNullException(nameof(Name)); }
        }

        public string       Surname
        {
            get { return _surname; }
            set { _surname = value ?? throw new ArgumentNullException(nameof(Surname)); }
        }

        public DateTime     BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public int          BirthYear
        {
            get { return _birthDate.Year; }
            set { _birthDate = _birthDate.AddYears(-_birthDate.Year + value); }
        }

        public DateTime     Date
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }



#pragma warning disable CS8618 
        public Person()
#pragma warning restore CS8618 
        {

            Name =          string.Empty;
            Surname =       string.Empty;
            BirthDate =     DateTime.MinValue;

        }

#pragma warning disable CS8618 
        public Person(string name, string surname, DateTime birthDate)
#pragma warning restore CS8618 
        {

            Name =          name;
            Surname =       surname;
            BirthDate =     birthDate;

        }



        public override string ToString()
        {
            return "Name: " + Name + "; surname: " + Surname + "; date of birth: " + BirthDate;
        }

        public virtual string ToShortString()
        {
            return "Name: " + Name + "; surname: " + Surname;
        }



        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object? obj)
        {

            if(obj == null)
            {
                return false;
            }

            if(obj.GetType() != typeof(Person)) 
            {
                return false;
            }

            Person t = (Person)obj;

            if(t.Name != Name || t.Surname != Surname || t.BirthDate != BirthDate) 
            {
                return false;
            }
            
            return true;

        }



        public static bool operator == (Person? a, Person? b)
        {

            return !(a != b);

        }

        public static bool operator != (Person? a, Person? b)
        {

            if ((object?)a == null)
            {
                if ((object?)b == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return !a.Equals(b);

        }



        public virtual object DeepCopy()
        {
#pragma warning disable CS8604 
            return new Person(Name.Clone().ToString(),
                Surname.Clone().ToString(), BirthDate);
#pragma warning restore CS8604 
        }



        public int CompareTo(object? other)
        {

            if(other == null) 
            {
                return 1;
            }

            Person? person = other as Person;

            if(person != null)
            {
                return person.Surname.CompareTo(Surname);
            }

            throw new ArgumentException("Given object can't be converted into \"Person\" type");

        }

        public int Compare(Person? person1, Person? person2)
        {

            if(person1 == null) 
            {
                if(person2 == null) 
                {
                    return 0;
                }

                return -1;

            }

            if (person2 == null)
            {

                return 1;

            }

            return DateTime.Compare(person1.BirthDate, person2.BirthDate);

        }

    }

}
