using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;



[assembly: Dependency(typeof(TestADAL.Droid.Helper.Authenticator))]
namespace TestADAL.Droid.Helper
{
    class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string clientId, string returnUri, string policy)
        {
            
            AuthenticationContext authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            // var platformParams = new PlatformParameters((Activity)Forms.Context);


            //var authResult = await authContext.AcquireTokenAsync(new string[] { clientId }, null, clientId, new Uri(returnUri), platformParams, "B2C_1_TestB2C");

            AuthenticationResult authResult = await authContext.AcquireTokenAsync(new string[] { clientId }, null, clientId, new Uri(returnUri), new PlatformParameters((Activity)Forms.Context), policy);

            //var authResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri), new PlatformParameters((Activity)Forms.Context));

            
            return authResult;
        }
    }
}