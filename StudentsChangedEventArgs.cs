using CLab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab_2
{
    internal class StudentsChangedEventArgs<TKey> : System.EventArgs
    {
        public string NameCollection { get; set; }        //Имя изменяемой коллекции

        public StudentCollections<TKey>.Action Action { get; set; }        //Действие в коллекции

        public string NameStudChangeProperty { get; set; }        //Имя изменяемого свойства элемента

        public TKey KeyElement { get; set; }                     //Ключ удалённого или добавленного элемента


        public StudentsChangedEventArgs(string name, StudentCollections<TKey>.Action action, string property, TKey key)
        {
            NameCollection = name;
            Action = action;
            NameStudChangeProperty = property;
            KeyElement = key;
        }


        public override string ToString()
        {
            return $"Collection name - {NameCollection} \nType of change - {Action} \nKey change object - {KeyElement} \nChange Property - {NameStudChangeProperty}";
        }
    }
    
}
