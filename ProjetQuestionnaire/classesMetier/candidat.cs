using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetQuestionnaire.classesMetier
{
    public class candidat
    {
        public int idCandidat { get; set; }
        public string login { get; set; }
        public string motDePasse { get; set; }

        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public override string ToString()
        {
            return this.nom + " " + this.prenom;
        }
    }

}
