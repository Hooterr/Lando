using Lando.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            //await Task.Delay(2000); // For dramatic effect

            var success = await sessionManager.StoredTokenExistsAsync();
            if (success)
            {
                //await Shell.Current.GoToAsync("//home");
                await Shell.Current.GoToAsync("//browse");
                return;
            }

            await Shell.Current.GoToAsync("//loginstart");
        }

    }
}
