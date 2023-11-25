using CSharp_Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class TeamsJournal
    {

        List<TeamsJournalEntry> _changesRegister;



        public TeamsJournal()
        { 
            _changesRegister = new List<TeamsJournalEntry>();
        }



        public void GraduateStudentsChanged<TKey>(object sender, GraduateStudentsChangedEventArgs<TKey> e)
        {
            _changesRegister.Add(new TeamsJournalEntry(e.CollectionName, e.Revision, e.PropertyName, e.YearOfStudy));
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var change in _changesRegister)
            {
                sb.Append(change.ToString() + "\n-----------------------------------\n");
            }

            return sb.ToString();

        }

    }
}
