using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using ProjetQuestionnaire.classesMetier;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetQuestionnaire.classesMetier
{
    public class DataQuiz
    {
        public List<candidat> listCandidat;
        public List<categorie> listCategorie;
        public List<question> listAllQuestions;
        public List<Reponse> listAllReponses;

        public HttpClient hc;

        public DataQuiz()
        {

            hc = new HttpClient();
        }
        public async Task setLesCandidats()
        {
            // r~~écupération des candidats
            listCandidat = new List<candidat>();
            var reponse = await hc.GetStringAsync("http://10.0.2.2/ApiQuiz/loginCandidat.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse);
            var list = donnees["results"]["candidat"];

            foreach (var item in list)
            {
                candidat unCandidat = new candidat()
                {
                    nom = item["nom"].Value.ToString(),
                    prenom = item["prenom"].Value.ToString(),
                    login = item["login"].Value.ToString(),
                    motDePasse = item["motDePasse"].Value.ToString()
                };

                listCandidat.Add(unCandidat);
            }

        }
        public async Task setLesCategories()
        {
            listCategorie = new List<categorie>();
            var reponse = await hc.GetStringAsync("http://10.0.2.2/ApiQuiz/getAllCategorie.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse);
            var list = donnees["results"]["categorie"];

            foreach (var item in list)
            {
                categorie uneCategorie = new categorie()
                {
                    idQuestionnaire = Convert.ToInt32(item["idQuestionnaire"].Value.ToString()),
                    libelleQuestionnaire = item["libelleQuestionnaire"].Value.ToString(),

                };

                listCategorie.Add(uneCategorie);
            }
        }
        public async Task getAllQuestions()
        {

            listAllQuestions = new List<question>();
            var reponse = await hc.GetStringAsync("http://10.0.2.2/ApiQuiz/getAllQuestions.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse);
            var list = donnees["results"]["question"];

            foreach (var item in list)
            {
                question uneQuestion = new question()
                {
                    idQuestionnaire = Convert.ToInt32(item["idQuestionnaire"].Value.ToString()),
                    idQuestion = Convert.ToInt32(item["idQuestion"].Value.ToString()),
                    libelleQuestion = item["libelleQuestion"].Value.ToString(),

                };

                listAllQuestions.Add(uneQuestion);
            }

        }
        public List<question> getQuestionParCategorie(int idCategorie)
        {
            List<question> QuestionParCateg = new List<question>();

            foreach (question q in listAllQuestions)
            {
                if (q.idQuestionnaire == idCategorie)
                {
                    QuestionParCateg.Add(q);
                }

            }
            return QuestionParCateg;
        }
        public async Task getAllReponses()
        {

            listAllReponses = new List<Reponse>();
            var reponse = await hc.GetStringAsync("http://10.0.2.2/ApiQuiz/getAllReponses.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse);
            var list = donnees["results"]["Reponse"];

            foreach (var item in list)
            {
                Reponse uneReponse = new Reponse()
                {
                    idQuestion = Convert.ToInt32(item["idQuestion"].Value.ToString()),
                    idReponse = Convert.ToInt32(item["idReponse"].Value.ToString()),
                    valeur = item["valeur"].Value.ToString(),

                };

                listAllReponses.Add(uneReponse);
            }
        }

        public List<Reponse> getReponseParQuestion(int idQuestion)
        {
            List<Reponse> ReponseParQuestion = new List<Reponse>();

            foreach (Reponse r in listAllReponses)
            {
                if (r.idReponse == idQuestion)
                {
                    ReponseParQuestion.Add(r);
                }

            }
            return ReponseParQuestion;

        }


    }
}
