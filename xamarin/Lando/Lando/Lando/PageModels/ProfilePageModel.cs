using Lando.ApiModels;
using Lando.ApiModels.Profile;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DeleteContact = new AsyncCommand<Contact>(DeleteContactAsync);
            ChangeContact = new AsyncCommand<Contact>(ChangeContactAsync);
            AddContact = new AsyncCommand(AddContactAsync);
            this.sessionManager = sessionManager;
        }


        public MeModel Me { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public IAsyncCommand LogoutCommand { get; }
        public IAsyncCommand<Contact> DeleteContact { get; }
        public IAsyncCommand<Contact> ChangeContact { get; }
        public IAsyncCommand AddContact { get; }

        public override async Task InitializeAsync()
        {
            var response = await apiService.GetMeAsync();
            if (response.Failed)
            {
                return;
            }

            Me = response.Entity;

            await LoadContactsAsync();

            MessagingCenter.Subscribe<ProfileEditContactPageModel>(this, "RefreshContacts", async _ =>
            {
                await LoadContactsAsync();
            });

        }

        private async Task LoadContactsAsync()
        {
            var contacts = await apiService.GetContactsAsync();

            if (contacts.Failed)
            {
                return;
            }

            Contacts = new ObservableCollection<Contact>(contacts.Entity.Contacts);
        }

        private Task DeleteContactAsync(Contact item)
        {
            Contacts.Remove(item);
            return Task.CompletedTask;
        }

        private async Task ChangeContactAsync(Contact item)
        {
            ProfileEditContactPageModel.PassedParameter = item;
            await Shell.Current.GoToAsync("contactEdit");
        }


        private async Task LogoutAsync()
        {
            await sessionManager.LogoutAsync();
            await Shell.Current.GoToAsync("//loginstart");
        }

        private async Task AddContactAsync()
        {
            await Shell.Current.GoToAsync("contactEdit");
        }

    }
}
