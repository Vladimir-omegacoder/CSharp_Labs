using S1_CLab3;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CLab3
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
    enum Education
    {
        Nobody,
        Specialist,
        Bachelor,
        SecondEducation
    }



    class Program
    {
    }
}