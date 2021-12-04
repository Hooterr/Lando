using Xamarin.Forms;
using System.Diagnostics;

namespace Lando
{    public partial class LoginWebPage : ContentPage
    {
        public LoginWebPage()
        {
            InitializeComponent();
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsVisible = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsVisible = true;
        }
    }
}