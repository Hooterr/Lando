using Lando.ApiModels;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class ProfilePageModel : BasePageModel
    {
        private readonly IApiService apiService;
        private readonly ISessionManager sessionManager;

        public ProfilePageModel(IApiService apiService, ISessionManager sessionManager)
        {
            this.apiService = apiService;
            LogoutCommand = new AsyncCommand(LogoutAsync);
            this.sessionManager = sessionManager;
        }

        public MeModel Me { get; set; }
        public IAsyncCommand LogoutCommand { get; }

        public override async Task InitializeAsync()
        {
            var response = await apiService.GetMeAsync();
            if (response.Failed)
            {
                return;
            }

            Me = response.Entity;

        }
        private async Task LogoutAsync()
        {
            await sessionManager.LogoutAsync();
            await Shell.Current.GoToAsync("//loginstart");
        }

    }
}
