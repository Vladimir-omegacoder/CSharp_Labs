using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class GraduateStudentListHandlerEventArgs : EventArgs
    {

        public string?   CollectionNameInfo  { get; private set; }

        public string?   ChangesInfo         { get; private set; }

        public int?      IndexInfo           { get; private set; }



        //Index < 0, means that no element has changed by the event
        //Provide null, if you want to miss some info
        public GraduateStudentListHandlerEventArgs(string? collectionName = null, string? changes = null, int? index = -1)
        {
            CollectionNameInfo = collectionName;
            ChangesInfo = changes;
            IndexInfo = index;
        }



        public override string ToString()
        {
            return "Collection name: " + (CollectionNameInfo ?? "N/A") + "; " +
                   "Changes: " + (ChangesInfo ?? "N/A") + "; " +
                   "Index: " + (IndexInfo?.ToString() ?? "N/A");
        }

    }
}
