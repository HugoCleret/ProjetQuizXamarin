using ProjetQuestionnaire.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace ProjetQuestionnaire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCandidats : ContentPage
    {
        DataQuiz mesdonnees;
        public PageCandidats(DataQuiz donneesRecup)
        {
            mesdonnees = donneesRecup;
            
            InitializeComponent();
           
        }

       // public async void chargerlesdonnees()
        //{
            //await mesdonnees.setLesCandidats();
           // lvCandidat.ItemsSource = mesdonnees.listCandidat;
        //}

        private  async void btLogin_Clicked(object sender, EventArgs e)
        {
            bool login = false;
            bool mdp = false;
            if (inputLog.Text !="" && inputMdp.Text!= "")
            {
                foreach(candidat c in mesdonnees.listCandidat)
                {
                    if(c.login == inputLog.Text && c.motDePasse == inputMdp.Text)
                    {
                        login = true;
                        mdp = true;
                        await  Navigation.PushAsync(new Pagecategories(mesdonnees));
                    }
                    else if (c.login == inputLog.Text && c.motDePasse != inputMdp.Text)
                    {
                        login = true;
                        break;
                    }

                }
                if(!login && !mdp)
                {
                    await DisplayAlert("Erreur", "Login ou Mot de passe incorrect.", "OK");
                }
                else if(login && !mdp)
                {
                    await DisplayAlert("Erreur", "Mot de passe incorrect", "OK");
                    
                }

            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez entrer un Login et un mot de Passe", "OK");
               
            }
        }
    }
}