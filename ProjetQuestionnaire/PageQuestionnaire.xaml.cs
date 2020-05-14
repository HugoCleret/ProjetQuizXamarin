using ProjetQuestionnaire.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ProjetQuestionnaire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQuestionnaire : ContentPage
    {

        DataQuiz mesdonnees;
        int compteur = 0;
        int bonneReponse = 0;
        int mauvaiseReponse = 0;

        public  PageQuestionnaire(categorie lacategorie, DataQuiz donneesRecup)
        {
            mesdonnees = donneesRecup;
          
            InitializeComponent();
            chargerlesquestions(lacategorie,mesdonnees);
          
        }
        public void chargerlesquestions(categorie lacategorie, DataQuiz donneesRecup)
        {
              
           
                List<question> ListquestionC = donneesRecup.getQuestionParCategorie(lacategorie.idQuestionnaire);
                labelQuestion.Text = ListquestionC[compteur].libelleQuestion;
                List<Reponse> ListReponseQ = donneesRecup.getReponseParQuestion(ListquestionC[compteur].idQuestion);
                Reponse1.Text = ListReponseQ[0].valeur;
                //Reponse2.Text = ListReponseQ[1].valeur;
                //Reponse3.Text = ListReponseQ[2].valeur;
                //Reponse4.Text = ListReponseQ[3].valeur;

            //int Max = donneesRecup.getQuestionParCategorie(lacategorie.idQuestionnaire).Count;
            //while (compteur != Max)
            //{
            //    if (Reponse1 != null)
            //    {
            //    compteur++;
            //    labelQuestion.Text = ListquestionC[compteur].libelleQuestion;

            //    }
            //}
        }

        
    }
}