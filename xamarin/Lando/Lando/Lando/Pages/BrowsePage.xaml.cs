using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace Lando
{
    public partial class BrowsePage : ContentPage
    {
        public BrowsePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Analytics.TrackEvent("CategoriesPageOpened");
        }
    }
}