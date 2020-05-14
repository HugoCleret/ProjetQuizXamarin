using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetQuestionnaire.classesMetier
{
    public class categorie
    {
        public int idQuestionnaire { get; set; }
        public string libelleQuestionnaire  { get; set; }
        public override string ToString()
        {
            return this.libelleQuestionnaire;
        }
    }
}
