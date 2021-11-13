using Lando.Services;
using Microsoft.Maui.Controls;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Threading.Tasks;

namespace Lando.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        private readonly IAuthenticationService api;

        public LoginPageModel(IAuthenticationService api)
        {
            LoginCommand = new AsyncCommand(LoginAsync);
            this.api = api;
        }


        public IAsyncCommand LoginCommand { get; }

        private async Task LoginAsync()
        {
            await api.AuthenticateWithoutCredentialsAsync();
            //await Shell.Current.GoToAsync("//home");
        }
    }
}
