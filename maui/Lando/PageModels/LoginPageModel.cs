using Lando.Services;
using Microsoft.Maui.Controls;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Threading.Tasks;

namespace Lando.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        private readonly IAuthenticationService api;

        public LoginPageModel(IAuthenticationService api)
        {
            LoginCommand = new AsyncCommand(LoginAsync);
            BrowserNavigatingCommand = new AsyncCommand<WebNavigatingEventArgs>(BrowserNavigationEventAsync);
            this.api = api;
        }

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand<WebNavigatingEventArgs> BrowserNavigatingCommand { get; }

        public string BrowserSource { get; set; }

        public override Task InitializeAsync()
        {
            return base.InitializeAsync();
        }

        private async Task BrowserNavigationEventAsync(WebNavigatingEventArgs args)
        {
            if (args == null)
            {
                return;
            }

            if (!Uri.TryCreate(args.Url, UriKind.Absolute, out var uri))
            {
                return;        
            }

            if (uri.Scheme != "lando" || string.IsNullOrEmpty(uri.AbsolutePath))
            {
                return;
            }

            // TODO auth
            await Shell.Current.GoToAsync("//home");
        }

        private async Task LoginAsync()
        {
            BrowserSource = "https://allegro.pl.allegrosandbox.pl/auth/oauth/authorize?response_type=code&client_id=b73814aa969745c99e28fbb75edc99bb&redirect_uri=http://vps-901e2495.vps.ovh.net";
            BrowserSource = "https://google.com";
            //await api.AuthenticateWithoutCredentialsAsync();
            //await Shell.Current.GoToAsync("//home");
        }
    }
}
