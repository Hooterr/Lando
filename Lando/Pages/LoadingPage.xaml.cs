using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Lando
{
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(600);
            TransitionIn();
        }

        async void TransitionIn()
        {
            
            await LoadingText.FadeTo(1, 800);
            
        }
    }
}