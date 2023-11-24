using Lab1;
using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2
{
    internal class GraduateStudentCollection<TKey> where TKey : IEquatable<TKey>
    {

#pragma warning disable CS0693
        public delegate TKey KeySelector<TKey>(GraduateStudent gs);
#pragma warning restore CS0693



        private Dictionary<TKey, GraduateStudent> _students;

        public string CollectionName { get; set; }

        private KeySelector<TKey> keySelector;

        //event GraduateStudentsChangedHandler<TKey> GraduateStudentsChanged; TODO



        public GraduateStudentCollection(KeySelector<TKey> keySelector)
        {
            CollectionName = nameof(CollectionName);
            this.keySelector = keySelector;
            _students = new Dictionary<TKey, GraduateStudent>();
        }



        public void AddDefaults()
        {

            int count = 10;

            for (int i = 0; i < count; ++i)
            {
                GraduateStudent gs = new GraduateStudent($"Name_{i + 1}", $"Surname_{i + 1}",
                    new DateTime(), new Person(), "", "", FormOfStudy.FullTime, 0);
                _students.Add(keySelector(gs), gs);
            }

        }

        public void AddGraduateStudent(params GraduateStudent[] students)
        {
            foreach (var gs in students)
            {
                _students.Add(keySelector(gs), gs);
            }
        }

        public override string ToString()
        {
            return string.Concat("\n\n", _students.Select(pair => pair.ToString()));
        }

        public string ToShortString() 
        {
            return string.Concat("\n\n", _students.Select(pair => '[' + pair.Key.ToString() + ", " + pair.Value.ToShortString() + ']'));
        }

        public bool Remove(GraduateStudent rt)
        {
            return _students.Remove(keySelector(rt));
        }

        public bool Replace(GraduateStudent gsOld, GraduateStudent gsNew)
        {

            TKey key = keySelector(gsOld);

            if(_students.ContainsKey(key))
            {
                _students[key] = gsNew;
                return true;
            }
            else
            {
                return false;
            }

        }

        public int MaxYearOfStudy
        {
            get { return _students.Count == 0? -1 : _students.Select(gs => gs.Value.YearOfStudy).Max(); }
        }

        IEnumerable<KeyValuePair<TKey, GraduateStudent>> TuitionForm(FormOfStudy value)
        {
            return _students.Where(pair => pair.Value.FormOfstudy == value);
        }

        IEnumerable<IGrouping<FormOfStudy, KeyValuePair<TKey, GraduateStudent>>> GroupByFormOfStudy
        {
            get { return _students.GroupBy(pair => pair.Value.FormOfstudy); }
        }

    }
}
