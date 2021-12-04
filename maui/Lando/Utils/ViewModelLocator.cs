using Lando.PageModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Lando
{
    public static class ViewModelLocator
    {
        public static readonly IReadOnlyDictionary<Type, Type> PageModelMapping;

        static ViewModelLocator()
        {
            PageModelMapping = new Dictionary<Type, Type>()
            {
                { typeof(LoginPage), typeof(LoginPageModel) },
                { typeof(HomePage), typeof(HomePageModel) },
                { typeof(BrowsePage), typeof(BrowsePageModel) },
                { typeof(CartPage), typeof(CartPageModel) },
                { typeof(ProfilePage), typeof(ProfilePageModel) },
                { typeof(LoadingPage), typeof(LoadingPageModel) },
            };

        }


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
            var view = bindable as Element;

            var viewType = view?.GetType();

            if (!PageModelMapping.TryGetValue(viewType, out var viewModelType))
            {
                return;
            }
            
            var viewModel = (BasePageModel)MauiProgram.ServiceProvider.GetService(viewModelType);
            if (viewModel == null)
            {
                return;
            }
            view.BindingContext = viewModel;

            await viewModel.InitializeAsync();
        }
    }
}
