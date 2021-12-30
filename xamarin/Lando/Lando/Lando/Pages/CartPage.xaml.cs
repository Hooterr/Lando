using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace Lando
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Analytics.TrackEvent("CartPageOpened");
        }
    }
}