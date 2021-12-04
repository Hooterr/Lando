using Lando.Services;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Lando.PageModels
{
    public class LoginStartPageModel : BasePageModel
    {
        private readonly ISessionManager sessionManager;

        public LoginStartPageModel(ISessionManager sessionManager)
        {
            LoginCommand = new AsyncCommand(LoginAsync);
            ContinueWithoutLoginCommand = new AsyncCommand(ContinueWithoutLoginAsync);
            this.sessionManager = sessionManager;
        }

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand ContinueWithoutLoginCommand { get; }

        private async Task LoginAsync()
        {
            await Shell.Current.GoToAsync("/loginweb");
        }

        private async Task ContinueWithoutLoginAsync()
        {
            if (await sessionManager.AuthenticateWithoutCredentialsAsync())
            {
                await Shell.Current.GoToAsync("//browse");
            }
        }

    }
}
