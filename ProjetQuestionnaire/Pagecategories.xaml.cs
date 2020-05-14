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
    public partial class Pagecategories : ContentPage
    {

        DataQuiz mesdonnees;
        public Pagecategories(DataQuiz donneesRecup)
        {
            mesdonnees = donneesRecup;
            InitializeComponent();
            lvCategorie.ItemsSource = mesdonnees.listCategorie;
        }

        private async void lvCategorie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvCategorie.SelectedItem != null){
               
                await Navigation.PushAsync(new PageQuestionnaire(lvCategorie.SelectedItem as categorie,mesdonnees));
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez choisir une catégorie de questionnaire.", "OK");
            }

            
            
        }
    }
}