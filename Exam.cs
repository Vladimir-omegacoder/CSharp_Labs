using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab1
{
    internal class Exam : IDateAndCopy
    {
        public string ExamName { get; set; }
        public int Grade { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime Date { get; set; }



        public Exam(string itemName, int grade, DateTime examDate)
        {
            ExamName = itemName;
            Grade = grade;
            ExamDate = examDate;
        }

        public Exam()
        {
            ExamName = string.Empty;
            Grade = 0;
            ExamDate = new DateTime();
        }



        public override string ToString()
        {
            return $"\tExamName - {ExamName}   Grade - {Grade}   ExamDate - {ExamDate.ToString("dd MMMM yyyy")}";
        }



        public object DeepCopy()
        {
            Exam c = new Exam(ExamName, Grade, ExamDate);
            return c;
        }



        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Exam))
            {
                return false;
            }
            Exam person = (Exam)obj;
            return ExamName == person.ExamName && Grade == person.Grade && ExamDate == person.ExamDate;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
