﻿using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2
{
    internal class GraduateStudentsChangedEventArgs<TKey> : EventArgs
    {

        public string CollectionName { get; set; }

        public GraduateStudent.Revision Revision { get; set; }

        public string PropertyName { get; set; }

        public int YearOfStudy { get; set; }



        public GraduateStudentsChangedEventArgs(string collectionName, GraduateStudent.Revision revision, string propertyName, int yearOfStudy)
        {
            CollectionName = collectionName;
            Revision = revision;
            PropertyName = propertyName;
            YearOfStudy = yearOfStudy;
        }

        

        public override string ToString()
        {
            return nameof(CollectionName) + ": " + CollectionName + "; " +
                nameof(Revision) + ": " + Revision + "; " +
                nameof(PropertyName) + ": " + PropertyName + "; " +
                nameof(YearOfStudy) + ": " + YearOfStudy;
        }

    }
}
