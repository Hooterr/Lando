using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace Lando
{    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Webview_HandlerChanged(object sender, System.EventArgs e)
        {
            Debug.WriteLine("1");
        }

        private void Webview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Debug.WriteLine("2");
        }

        private void Webview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Debug.WriteLine("3");
        }
    }
}