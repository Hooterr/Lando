using Lando.ApiModels.Authentication;
using Lando.Async;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

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
            return AsyncAwaiter.AwaitResultAsync(nameof(SessionManager), async () =>
            {
                if (IsExpired())
                {
                    if (!await RefreshTokenInternalAsync())
                    {
                        return string.Empty;
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

        public Task<bool> StoredTokenExistsAsync()
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
                    if (!await RefreshTokenInternalAsync())
                    {
                        return false;
                    }
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
            _validTo = jwtToken.ValidTo.ToUniversalTime();
        }

        private void ClearTokenInternal()
        {
            _accessToken = null;
            _refreshToken = null;
            _validTo = DateTime.MinValue;
        }


        private async Task<bool> RefreshTokenInternalAsync()
        {
            var response = await _authService.RefreshTokenAsync(_refreshToken);
            if (response.Success)
            {
                SetTokenInternal(response.Entity);
                return true;
            }
            else
            {
                MessagingCenter.Send(Application.Current, "RefreshTokenFailed");
                return false;
            }
        }

        private async Task SaveTokenToStorageAsync(AuthenticationTokenResponse token)
        {
            await SecureStorage.SetAsync(TokenStorageKey, JsonConvert.SerializeObject(token));
        }

        private void ClearTokenFromStorage()
        {
            SecureStorage.Remove(TokenStorageKey);
        }


        public async Task<bool> AuthenticateWithoutCredentialsAsync()
        {
            var response = await _authService.AuthenticateClientCredentialsAsync();
            if (response.Failed)
            {
                return false;
            }

            await SetTokenAsync(response.Entity);

            return true;
        }

        public async Task<bool> AuthenticateAuthorizationCodeAsync(string code)
        {
            var response = await _authService.AuthenticateAuthorizationCodeAsync(code);
            if (response.Failed)
            {
                return false;
            }

            await SetTokenAsync(response.Entity);

            return true;
        }

        public Task LogoutAsync()
        {
            return AsyncAwaiter.AwaitAsync(nameof(SessionManager), () =>
            {
                ClearTokenInternal();
                ClearTokenFromStorage();
                return Task.CompletedTask;
            });
        }

        private bool IsExpired()
        {
            return DateTime.UtcNow > _validTo;
        }

    }
}
