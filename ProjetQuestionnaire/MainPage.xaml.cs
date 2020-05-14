using ProjetQuestionnaire.classesMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ProjetQuestionnaire
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        DataQuiz mesdonnees;
        public static INavigation GlobalNavigation { get; private set; }
        public MainPage()
        {
            mesdonnees = new DataQuiz();
            InitializeComponent();
            chargerlesdonnees();
        }
        public async void chargerlesdonnees()
        {
            await mesdonnees.setLesCandidats();
            await mesdonnees.setLesCategories();
            await mesdonnees.getAllQuestions();
            await mesdonnees.getAllReponses();
            //await mesdonnees.setLesQuestionsCinema();
            //await mesdonnees.setLesQuestionsCultureG();
            //await mesdonnees.setLesQuestionsFoot();
        }

        private async void btStart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageCandidats(mesdonnees),true);

        }
    }
}
