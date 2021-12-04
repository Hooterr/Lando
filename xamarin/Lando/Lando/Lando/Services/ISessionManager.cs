using Lando.ApiModels;
using Lando.ApiModels.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.Services
{
    public interface ISessionManager
    {
        Task<string> GetTokenAsync();
        Task<string> GetRefreshTokenAsync();
        Task SetTokenAsync(AuthenticationTokenResponse token);
        Task<bool> ReadFromStorageAsync();

        Task<bool> AuthenticateWithoutCredentialsAsync();
        Task<bool> AuthenticateAuthorizationCodeAsync(string code);

        Task LogoutAsync();
    }
}
