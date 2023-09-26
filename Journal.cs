using CLab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1_CLab1
{
    internal class Journal
    {
        private List<JournalEntry> JournalChange = new List<JournalEntry>();



        public void Changed(object sender, StudentListHandlerEventArgs e)
        {
            if (sender is StudentCollections)
            {
                JournalChange.Add(new JournalEntry(e.NameCollection, e.TypeChange, e.NameStudChange.ToString()));
            }
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
