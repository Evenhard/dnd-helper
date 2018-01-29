using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Paladin.Converters
{
    public class GetPreparedCheckboxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "ion-android-checkbox-outline" : "ion-android-checkbox-outline-blank";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
