using Lando.ApiModels;
using Lando.ApiModels.Authentication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lando.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly HttpClient httpClient;

        public AuthenticationService(IHttpClientFactory factory)
        {

            httpClient = factory.CreateClient("client_credentials");
        }

        public async Task<ApiResonseModel<AuthenticationTokenResponse>> AuthenticateAuthorizationCodeAsync(string code)
        {
            var response = await httpClient.PostAsync($"auth/oauth/token?grant_type=authorization_code&code={code}&redirect_uri=http://vps-901e2495.vps.ovh.net", null);
            if (response.IsSuccessStatusCode)
            {
                var @string = await response.Content.ReadAsStringAsync();
                var tokenReponse = JsonConvert.DeserializeObject<AuthenticationTokenResponse>(@string);
                return new ApiResonseModel<AuthenticationTokenResponse>()
                {
                    Success = true,
                    Entity = tokenReponse
                };
            }

            return new ApiResonseModel<AuthenticationTokenResponse>()
            {
                Success = false,
            };
        }


        public async Task<ApiResonseModel<AuthenticationTokenResponse>> AuthenticateClientCredentialsAsync()
        {
            var response = await httpClient.PostAsync("auth/oauth/token?grant_type=client_credentials", null);
            if (response.IsSuccessStatusCode)
            {
                var @string = await response.Content.ReadAsStringAsync();
                var tokenReponse = JsonConvert.DeserializeObject<AuthenticationTokenResponse>(@string);
                return new ApiResonseModel<AuthenticationTokenResponse>()
                {
                    Success = true,
                    Entity = tokenReponse
                };
            }

            return new ApiResonseModel<AuthenticationTokenResponse>()
            {
                Success = false,
            };
        }

        public async Task<ApiResonseModel<AuthenticationTokenResponse>> RefreshTokenAsync(string refreshToken)
        {
            var response = await httpClient.PostAsync($"auth/oauth/token?grant_type=refresh_token&refresh_token={refreshToken}", null);

            if (response.IsSuccessStatusCode)
            {
                var @string = await response.Content.ReadAsStringAsync();
                var tokenReponse = JsonConvert.DeserializeObject<AuthenticationTokenResponse>(@string);
                return new ApiResonseModel<AuthenticationTokenResponse>()
                {
                    Success = true,
                    Entity = tokenReponse
                };
            }

            return new ApiResonseModel<AuthenticationTokenResponse>()
            {
                Success = false,
            };
        }
    }
}
