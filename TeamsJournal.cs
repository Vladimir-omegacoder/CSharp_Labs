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



        void GraduateStudentCollectionExpand(object sender, GraduateStudentListHandlerEventArgs e)
        {
            _changesRegister.Add(new TeamsJournalEntry(e.CollectionNameInfo, e.ChangesInfo, e.IndexInfo));
        }



        TeamsJournal()
        {
            _changesRegister = new List<TeamsJournalEntry>();
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var entry in _changesRegister)
            {
                sb.Append(entry.ToString() + '\n');
            }

            return sb.ToString();
        }

    }
}
