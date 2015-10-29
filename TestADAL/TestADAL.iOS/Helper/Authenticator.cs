using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using Foundation;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestADAL.iOS.Helper.Authenticator))]
namespace TestADAL.iOS.Helper
{
    class Authenticator : IAuthenticator
    {
        public async System.Threading.Tasks.Task<AuthenticationResult> Authenticate(string authority, string clientId, string returnUri, string policy)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            var platformParams = new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController);


            //var authResult = await authContext.AcquireTokenAsync(new string[] { clientId }, null, clientId, new Uri(returnUri), platformParams, "B2C_1_TestB2C");
            var authResult = await authContext.AcquireTokenAsync(new string[] { clientId }, null, clientId, new Uri(returnUri), platformParams, policy);

            

            //var authResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri),
            //    new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController));
            return authResult;
        }
    }
}