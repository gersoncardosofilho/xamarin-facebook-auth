using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginFacebookV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginFacebookV2Page());
        }

        public static Action HideLoginView
        {
            get
            {
                return new Action(()=> Current.MainPage.Navigation.PopModalAsync());
            }

        }

        public async static Task NavigateToProfile(string message)
        {
            await Current.MainPage.Navigation.PushAsync(new Profile(message));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
