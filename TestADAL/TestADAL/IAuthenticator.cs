using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;

namespace TestADAL
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string clientId, string returnUri, string policy);
    }
}
