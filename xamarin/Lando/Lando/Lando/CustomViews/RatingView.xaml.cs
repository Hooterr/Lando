using Lando.ApiModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lando.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingView : ContentView
    {
        public RatingView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty ModelProperty = BindableProperty.Create(nameof(Model), typeof(UserRatingResponseModel), typeof(RatingView), propertyChanged: ModelPropertyChanged);

        public UserRatingResponseModel Model
        {
            get => (UserRatingResponseModel)GetValue(ModelProperty);
            set
            {
                SetValue(ModelProperty, value);
                OnPropertyChanged(nameof(Model));
            }
        }

        private static void ModelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((RatingView)bindable).OnPropertyChanged(nameof(Model));
        }
    }
}