using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Paladin.Converters
{
    public class GetColorFromIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var hex = (int)value;

            switch (hex)
            {
                case 1:
                    return Color.FromHex("#ff0000");

                case 2:
                    return Color.FromHex("#00ff00");

                default:
                    return Color.FromHex("#0000ff");
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
