using Lando.ApiModels;
using Lando.ApiModels.Authentication;
using System.Threading.Tasks;

namespace Lando.Services
{
    public interface IAuthenticationService
    {
        Task<ApiResonseModel<AuthenticationTokenResponse>> AuthenticateWithoutCredentialsAsync();
        Task<ApiResonseModel<AuthenticationTokenResponse>> RefreshTokenAsync(string refreshToken);
    }
}
