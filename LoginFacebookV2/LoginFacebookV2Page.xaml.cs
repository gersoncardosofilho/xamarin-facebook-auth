using Xamarin.Forms;

namespace LoginFacebookV2
{
    public partial class LoginFacebookV2Page : ContentPage
    {
        public LoginFacebookV2Page()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
