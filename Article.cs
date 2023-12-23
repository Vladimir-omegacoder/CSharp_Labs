using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    [Serializable]
    internal class Article
    {

        public string       Title         { get; set; }
        public string       PublPlace     { get; set; }
        public DateTime     PublDate      { get; set; }



        public Article()
        {
            Title =        "";
            PublPlace =    "";
            PublDate =     new DateTime();
        }

        public Article(string title, string publ_place, DateTime publ_date)
        {
            Title =       title;
            PublPlace =   publ_place;
            PublDate =    publ_date;
        }



        public override string ToString()
        {
            return "Title: " + Title + "; publishing place: " + PublPlace + "; publishing date: " + PublDate;
        }

    }

}
