using Lando.ApiModels;
using Lando.ApiModels.Authentication;
using System.Threading.Tasks;

namespace Lando.Services
{
    public interface IAuthenticationService
    {
        Task<ApiResonseModel<AuthenticationTokenResponse>> AuthenticateAuthorizationCodeAsync(string code);
        Task<ApiResonseModel<AuthenticationTokenResponse>> AuthenticateClientCredentialsAsync();
        Task<ApiResonseModel<AuthenticationTokenResponse>> RefreshTokenAsync(string refreshToken);
    }
}
