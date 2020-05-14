using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetQuestionnaire.classesMetier
{
    public class Reponse
    {
        public int idQuestion { get; set; }
        public int idReponse { get; set; }
        public string valeur { get; set; }

        public override string ToString()
        {
            return this.valeur;
        }
    }

   
}
