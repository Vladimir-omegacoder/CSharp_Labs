
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab1
{
    internal class StudentListHandlerEventArgs: EventArgs
    {
        public string NameCollection { get; set; }

        public string TypeChange { get; set; }

        public Student NameStudChange{ get; set; }



        public StudentListHandlerEventArgs()
        {
            NameCollection = string.Empty;
            TypeChange = string.Empty;
            NameStudChange = new Student();
        }


        public StudentListHandlerEventArgs(string name, string type, Student studenet)
        {
            NameCollection=name;
            TypeChange=type;
            NameStudChange = studenet;
        }



        public override string ToString()
        {
            return $"Collection name - {NameCollection} \nType of change - {TypeChange} \nChange object - {NameStudChange.ToShortString()}";
        }
    }
}
