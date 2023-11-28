using CLab_2;
using CLab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1_CLab2
{
    internal class Journal
    {
        private List<JournalEntry> JournalChange = new List<JournalEntry>();



        public void Changed(object sender, StudentsChangedEventArgs<string> e)
        {
            JournalChange.Add(new JournalEntry(e.NameCollection, e.Action, e.NameStudChangeProperty, e.KeyElement));
        }



        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < JournalChange.Count(); i++)
            {
                s += JournalChange[i].ToString();
                s += "\n";
            }
            return s;
        }
    }
}
