using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class TeamsJournalEntry
    {

        public string?  CollectionName  { get; private set; }

        public string?  Changes         { get; private set; }

        public int?     Index           { get; private set; }



        //Provide null, if you want to miss some info
        public TeamsJournalEntry
            (string? collectionName = null, string? changes = null, int? index = null)
        {
            CollectionName = collectionName;
            Changes = changes;
            Index = index;
        }



        public override string ToString()
        {
            return "Collection name: " + (CollectionName ?? "N/A") + "; " +
                   "Changes: " + (Changes ?? "N/A") + "; " +
                   "Index: " + (Index?.ToString() ?? "N/A");
        }

    }
}
