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

#pragma warning disable CS0693
        public delegate void GraduateStudentsChangedHandler<TKey>(object source, GraduateStudentsChangedEventArgs<TKey> args);
#pragma warning restore CS0693

        public event GraduateStudentsChangedHandler<TKey>? GraduateStudentsChanged;



        public GraduateStudentCollection(KeySelector<TKey> keySelector)
        {
            CollectionName = nameof(CollectionName);
            this.keySelector = keySelector;
            _students = new Dictionary<TKey, GraduateStudent>();
        }



        private void GsPropertyChanged(object source, System.ComponentModel.PropertyChangedEventArgs e)
        {

#pragma warning disable CS8604
            GraduateStudentsChanged?.Invoke(source,
                new GraduateStudentsChangedEventArgs<TKey>(CollectionName, GraduateStudent.Revision.Property,
                e.PropertyName, ((GraduateStudent)source).YearOfStudy));
#pragma warning restore CS8604

        }

        public void AddDefaults()
        {

            int count = 10;

            for (int i = 0; i < count; ++i)
            {
                GraduateStudent gs = new GraduateStudent($"Name_{i + 1}", $"Surname_{i + 1}",
                    new DateTime(), new Person(), "", "", FormOfStudy.FullTime, 1);
#pragma warning disable CS8622
                gs.PropertyChanged += GsPropertyChanged;
#pragma warning restore CS8622 
                _students.Add(keySelector(gs), gs);
            }

        }

        public void AddGraduateStudent(params GraduateStudent[] students)
        {
            foreach (var gs in students)
            {
#pragma warning disable CS8622
                gs.PropertyChanged += GsPropertyChanged;
#pragma warning restore CS8622
                _students.Add(keySelector(gs), gs);
            }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var pair in _students)
            {
                sb.Append(pair.ToString() + "\n-----------------------------------\n");
            }

            return sb.ToString();

        }

        public string ToShortString() 
        {

            StringBuilder sb = new StringBuilder();

            foreach (var pair in _students)
            {
                sb.Append('[' + pair.Key.ToString() + ", " + pair.Value.ToShortString() + ']' + "\n-----------------------------------\n");
            }

            return sb.ToString();

        }

        public bool Remove(GraduateStudent rt)
        {
            bool result = _students.Remove(keySelector(rt));
            if (result)
            {
#pragma warning disable CS8622
                rt.PropertyChanged -= GsPropertyChanged;
#pragma warning restore CS8622
                GraduateStudentsChanged?.Invoke(this, new GraduateStudentsChangedEventArgs<TKey>(CollectionName,
                    GraduateStudent.Revision.Remove, "", rt.YearOfStudy));
            }
            return result;
        }

        public bool Replace(GraduateStudent gsOld, GraduateStudent gsNew)
        {

            TKey key = keySelector(gsOld);

            if(_students.ContainsKey(key))
            {
                _students[key] = gsNew;

#pragma warning disable CS8622
                gsOld.PropertyChanged -= GsPropertyChanged;
#pragma warning restore CS8622

                GraduateStudentsChanged?.Invoke(this, new GraduateStudentsChangedEventArgs<TKey>(CollectionName,
                GraduateStudent.Revision.Replace, "", gsNew.YearOfStudy));
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

        public IEnumerable<KeyValuePair<TKey, GraduateStudent>> TuitionForm(FormOfStudy value)
        {
            return _students.Where(pair => pair.Value.FormOfstudy == value);
        }

        public IEnumerable<IGrouping<FormOfStudy, KeyValuePair<TKey, GraduateStudent>>> GroupByFormOfStudy
        {
            get { return _students.GroupBy(pair => pair.Value.FormOfstudy); }
        }

    }
}
