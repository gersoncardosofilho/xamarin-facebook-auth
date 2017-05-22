using System;
using Android.App;
using LoginFacebookV2;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(Login), typeof(LoginFacebookV2.Droid.FBLoginPageRenderer))]

namespace LoginFacebookV2.Droid
{
    public class FBLoginPageRenderer : PageRenderer
    {
        public FBLoginPageRenderer()
        {
            var activity = this.Context as Activity;
            var auth = new OAuth2Authenticator(
                clientId: "112169139364110",   //  seu cliente id OAuth2 client id
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");

                    await App.NavigateToProfile(string.Format("Olá {0}, seja bem-vindo", name));
                }
                else
                {
                    await App.NavigateToProfile("Usuário Cancelou o login");
                }
            };

            activity.StartActivity((Android.Content.Intent)auth.GetUI(activity));
        }
    }
}
