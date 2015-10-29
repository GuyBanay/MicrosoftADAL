using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestADAL
{
    public partial class HomePage : ContentPage
    {
        public static string clientId = "";     
        public static string authority = "";        
        public static string returnUri = "urn:ietf:wg:oauth:2.0:oob";
        public static string policy = "";

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var token = "No token";
            try
            {
                var data = await DependencyService.Get<IAuthenticator>()
                    .Authenticate(authority, clientId, returnUri, policy);

                if (data.Token != null)
                    token = data.Token;
            }
            catch (Exception ex)
            {
                token = ex.Message;
            }
            await DisplayAlert("Token", token, "Ok", "Cancel");
        }
    }
}
