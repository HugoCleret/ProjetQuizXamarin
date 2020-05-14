using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetQuestionnaire
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();

            var rootPage = new NavigationPage(new ProjetQuestionnaire.MainPage());

            GlobalNavigation = rootPage.Navigation;

            MainPage = rootPage;
         

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
