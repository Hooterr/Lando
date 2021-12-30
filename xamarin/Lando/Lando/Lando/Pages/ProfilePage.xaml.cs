using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace Lando
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Analytics.TrackEvent("ProfilePageOpened");
        }
    }
}