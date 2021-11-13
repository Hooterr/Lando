using Microsoft.Maui.Controls;
using System;
using System.Reflection;

namespace Lando
{
    public static class ViewModelLocator
    {
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

        private static void AutoWireViewModelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;

            var viewType = view?.GetType();
            if (viewType?.FullName == null)
            {
                return;
            }

            var viewName = viewType.Name;
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = $"{viewName}Model";

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = MauiProgram.ServiceProvider.GetService(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
