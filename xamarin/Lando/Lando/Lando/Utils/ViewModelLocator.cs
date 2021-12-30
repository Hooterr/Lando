using Lando.PageModels;
using System;
using System.Collections.Generic;
using System.Web;
using Xamarin.Forms;

namespace Lando
{
    public static class ViewModelLocator
    {
        // Page -> ViewModel mapping
        public static readonly IReadOnlyDictionary<Type, Type> PageModelMapping = new Dictionary<Type, Type>()
        {
            { typeof(LoginWebPage), typeof(LoginWebPageModel) },
            { typeof(LoginStartPage), typeof(LoginStartPageModel) },
            { typeof(HomePage), typeof(HomePageModel) },
            { typeof(BrowsePage), typeof(BrowsePageModel) },
            { typeof(ProductListPage), typeof(ProductListPageModel) },
            { typeof(OfferDetailsPage), typeof(OfferDetailsPageModel) },
            { typeof(CartPage), typeof(CartPageModel) },
            { typeof(ProfilePage), typeof(ProfilePageModel) },
            { typeof(LoadingPage), typeof(LoadingPageModel) },
            { typeof(ProfileEditContactPage), typeof(ProfileEditContactPageModel) },
        };

        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.Create(
            "AutoWireViewModel",
            typeof(bool),
            typeof(ViewModelLocator),
            default(bool),
            propertyChanged: AutoWireViewModelPropertyChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
            => (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
            => bindable.SetValue(AutoWireViewModelProperty, value);

        private async static void AutoWireViewModelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ContentPage;
            var viewType = view?.GetType();
            if (!PageModelMapping.TryGetValue(viewType, out var viewModelType))
            {
                return;
            }
            var viewModel = (BasePageModel)App.ServiceProvider.GetService(viewModelType);
            if (viewModel == null)
            {
                return;
            }

            view.Appearing += (s, e) => viewModel.OnAppeared();
            view.Disappearing += (s, e) => viewModel.OnDissapeared();

            view.BindingContext = viewModel;
            await viewModel.InitializeAsync();
        }
    }
}
