using Lando.ApiModels.Authentication;
using Lando.Async;
using Microsoft.Maui.Essentials;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

namespace Lando.Services
{
    public class SessionManager : ISessionManager
    {
        private const string TokenStorageKey = "TokenStorageKey";

        private string _accessToken;
        private string _refreshToken;
        private readonly IAuthenticationService _authService;
        private DateTime _validTo;
        
        public SessionManager(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public Task<string> GetTokenAsync()
        {
            return AsyncAwaiter.AwaitResultAsync(nameof(Services.SessionManager), async () =>
            {
                if (IsExpired())
                {
                    var response = await _authService.RefreshTokenAsync(_refreshToken);
                    if (response.Success)
                    {
                        SetTokenInternal(response.Entity);
                    }
                    else
                    {
                        // To live is to suffer
                        Debugger.Break();
                    }
                }

                return _accessToken;
            });
        }

        public Task<string> GetRefreshTokenAsync()
        {
            return AsyncAwaiter.AwaitResultAsync(nameof(SessionManager), () =>
            {
                return Task.FromResult(_refreshToken);
            });
        }

        public Task SetTokenAsync(AuthenticationTokenResponse token)
        {
            return AsyncAwaiter.AwaitAsync(nameof(SessionManager), async () =>
            {
                SetTokenInternal(token);
                await SaveTokenToStorageAsync(token);
            });
        }

        public Task<bool> ReadFromStorageAsync()
        {
            return AsyncAwaiter.AwaitResultAsync(nameof(SessionManager), async () =>
            {
                var storedToken = await SecureStorage.GetAsync(TokenStorageKey);
                if (string.IsNullOrEmpty(storedToken))
                {
                    return false;
                }

                var tokenObject = JsonConvert.DeserializeObject<AuthenticationTokenResponse>(storedToken);
                if (tokenObject == null)
                { 
                    return false; 
                }

                SetTokenInternal(tokenObject);

                if (IsExpired())
                {
                    return false;
                }

                return true;
            });

        }

        private void SetTokenInternal(AuthenticationTokenResponse token) 
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token.AccessToken);
            _accessToken = token.AccessToken;
            _refreshToken = token.RefreshToken;
            _validTo = jwtToken.ValidTo;
        }

        private async Task SaveTokenToStorageAsync(AuthenticationTokenResponse token)
        {
            await SecureStorage.SetAsync(TokenStorageKey, JsonConvert.SerializeObject(token));
        }

        public async Task<bool> AuthenticateWithoutCredentialsAsync()
        {
            var response = await _authService.AuthenticateWithoutCredentialsAsync();
            if (response.Failed)
            {
                return false;
            }

            await SetTokenAsync(response.Entity);

            return true;
        }


        private bool IsExpired()
        {
            return DateTime.UtcNow > _validTo;
        }
    }
}
