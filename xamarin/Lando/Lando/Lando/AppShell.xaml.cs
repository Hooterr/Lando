using Xamarin.Forms;

namespace Lando
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("loginweb", typeof(LoginWebPage));
            Routing.RegisterRoute("productdetails", typeof(ProductListPage));
            Routing.RegisterRoute("offerdetails", typeof(OfferDetailsPage));
            Routing.RegisterRoute("contactEdit", typeof(ProfileEditContactPage));
            CurrentItem = LoadingShell;
        }

    }
}
