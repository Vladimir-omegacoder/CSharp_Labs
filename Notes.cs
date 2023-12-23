using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    [Serializable]
    internal class Notes
    {

        public string       ThesesName
        {
            get; set;
        }

        public string       ConferenceName
        {
            get; set;
        }

        public DateTime     PublicationDate
        {
            get; set;
        }



        public Notes(string theses_name, string conference_name, DateTime publication_date)
        {
            ThesesName =        theses_name;
            ConferenceName =    conference_name;
            PublicationDate =   publication_date;
        }

        public Notes()
        {
            ThesesName =        "";
            ConferenceName =    "";
            PublicationDate =   new DateTime();
        }

        public override string ToString()
        {
            return "Theses name: " + ThesesName + "; conference name: " + ConferenceName + "; publication date: " + PublicationDate;
        }

    }

}
