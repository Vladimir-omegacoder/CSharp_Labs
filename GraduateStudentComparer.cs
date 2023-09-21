using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class GraduateStudentComparer : IComparer<GraduateStudent>
    {
        public int Compare(GraduateStudent? student1, GraduateStudent? student2)
        {

            if(student1 == null)
            {
                if(student2 == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if(student2 == null)
            { 
                return 1;
            }

            return student1.YearOfStudy.CompareTo(student2.YearOfStudy);

        }

    }

}
