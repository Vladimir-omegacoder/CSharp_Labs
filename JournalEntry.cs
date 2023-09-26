using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1_CLab1
{
    internal class JournalEntry
    {
        public string NameCollection { get; set; }

        public string NameChange { get; set; }

        public string StudentChange { get; set; }



        public JournalEntry()
        {
            NameCollection = string.Empty;
            NameChange = string.Empty;
            StudentChange = string.Empty;
        }


        public JournalEntry(string nameCollection, string nameChange, string student)
        {
            NameCollection = nameCollection;
            NameChange = nameChange;
            StudentChange = student;
        }



        public override string ToString()
        {
            return $"Collection name - {NameCollection} \nType of change - {NameChange} \nChange object - {StudentChange}\n";
        }
    }
}
