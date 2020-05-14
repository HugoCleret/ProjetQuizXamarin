using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetQuestionnaire.classesMetier
{
    public class question
    {
        public int idQuestionnaire { get; set; }
        public int idQuestion { get; set; }
        public string libelleQuestion { get; set; }

        public override string ToString()
        {
            return this.libelleQuestion;
        }
    }
}
