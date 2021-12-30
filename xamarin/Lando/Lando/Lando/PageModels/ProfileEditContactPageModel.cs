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
    public class ProfileEditContactPageModel : BasePageModel, IQueryAttributable
    {
        public static Contact PassedParameter { get; set; }
        private readonly IApiService apiService;
        private Contact contact;

        public ProfileEditContactPageModel(IApiService apiService)
        {
            this.apiService = apiService;
            SaveCommand = new AsyncCommand(SaveAsync);
            CancelCommand = new AsyncCommand(CancelAsync);
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IAsyncCommand SaveCommand { get; }
        public IAsyncCommand CancelCommand { get; }

        public override async Task InitializeAsync()
        { 
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            Name = PassedParameter?.Name;
            Email = PassedParameter?.Emails[0].Address;
            Phone = PassedParameter?.Phones[0].Number;
            contact = PassedParameter;
            PassedParameter = null;
        }

        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("../");
        }

        private async Task SaveAsync()
        {
            bool isNewContact = contact == null;
            var editedContact = contact;

            editedContact ??= new Contact()
            {
                Emails = new List<Email>
                {
                    new Email(),
                },
                Phones = new List<Phone>
                {
                    new Phone(),
                }
            };

            editedContact.Name = Name;
            editedContact.Emails[0].Address = Email;
            editedContact.Phones[0].Number = Phone;


            ApiResonseModel<Contact> response;
            if (isNewContact)
            {
                response = await apiService.AddContactAsync(editedContact);
            }
            else
            {
                response = await apiService.ChangeContactAsync(editedContact);
            }
            if (response.Failed)
            {
                await Application.Current.MainPage.DisplayAlert("Nie udało się zapisać zmian", "Sprawdź czy poprawnie uzupełniłeś dane", "OK");
                return;
            }

            MessagingCenter.Send(this, "RefreshContacts");
            await Shell.Current.GoToAsync("../");

        }
    }
}
