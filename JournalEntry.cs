using CLab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1_CLab2
{
    internal class JournalEntry
    {
        public string NameCollection { get; set; }              //Имя изменяемой коллекции

        public StudentCollections<string>.Action Action { get; set; }              //Действие в коллекции

        public string NameStudChangeProperty { get; set; }        //Имя изменяемого свойства элемента

        public string KeyElement { get; set; }                     //Ключ удалённого или добавленного элемента



        public JournalEntry(string name, StudentCollections<string>.Action action, string property, string key)
        {
            NameCollection = name;
            Action = action;
            NameStudChangeProperty = property;
            KeyElement = key;
        }



        public override string ToString()
        {
            return $"Collection name - {NameCollection} \nType of change - {Action} \nKey change object - {KeyElement} \nChange Property - {NameStudChangeProperty}\n\n";
        }
    }
}
