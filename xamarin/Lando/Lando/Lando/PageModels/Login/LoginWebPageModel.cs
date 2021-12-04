using Lando.Services;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Lando.PageModels
{
    public class LoginWebPageModel : BasePageModel
    {
        private readonly IAuthenticationService api;
        private readonly ISessionManager sessionManager;

        public LoginWebPageModel(IAuthenticationService api, ISessionManager sessionManager)
        {
            LoginCommand = new AsyncCommand(LoginAsync);
            BrowserNavigatingCommand = new AsyncCommand<WebNavigatingEventArgs>(BrowserNavigationEventAsync);
            this.api = api;
            this.sessionManager = sessionManager;
        }

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand<WebNavigatingEventArgs> BrowserNavigatingCommand { get; }

        public string BrowserSource { get; set; }

        public override Task InitializeAsync()
        {
            BrowserSource = "https://allegro.pl.allegrosandbox.pl/auth/oauth/authorize?response_type=code&client_id=b73814aa969745c99e28fbb75edc99bb&redirect_uri=http://vps-901e2495.vps.ovh.net&prompt=confirm";
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
             
            if (uri.Host != "vps-901e2495.vps.ovh.net")
            {
                return;
            }

            var code = HttpUtility.ParseQueryString(uri.Query).Get("code");
            if (string.IsNullOrEmpty(code))
            {
                return;
            }


            if (!await sessionManager.AuthenticateAuthorizationCodeAsync(code))
            {
                return;
            }

            // TODO Lovely error handling
            await Shell.Current.GoToAsync("//home");
        }

        private async Task LoginAsync()
        {
            //BrowserSource = "https://google.com";
            //await api.AuthenticateWithoutCredentialsAsync();
            //await Shell.Current.GoToAsync("//home");
        }
    }
}
