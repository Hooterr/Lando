using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lando.Utils
{
    public class PolishPluralConverter : IValueConverter
    {
        public string SingularNominative { get; set; }
        public string PluralNominative { get; set; }
        public string PluralGenitive { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int vInt)
            {
                return Helpers.PolishPlural(vInt, SingularNominative, PluralNominative, PluralGenitive);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
