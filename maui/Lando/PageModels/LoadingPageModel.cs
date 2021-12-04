using Lando.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.PageModels
{
    public class LoadingPageModel : BasePageModel
    {
        private readonly ISessionManager sessionManager;

        public LoadingPageModel(ISessionManager sessionManager)
        {
            IsBusy = true;
            this.sessionManager = sessionManager;
        }

        public bool IsBusy { get; set; }

        public async override Task InitializeAsync()
        {
            
            await Task.Delay(2000); // For dramatic effect
            await AppShell.Current.GoToAsync("login");
            return;

            var success = await sessionManager.ReadFromStorageAsync();
            if (success)
            {
                await AppShell.Current.GoToAsync("//home");
                return;
            }

            success = await sessionManager.AuthenticateWithoutCredentialsAsync();

            if (success)
            {
                await AppShell.Current.GoToAsync("//home");
                return;
            }

            await AppShell.Current.GoToAsync("login");
        }

    }
}
