using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Paladin.Converters
{
    public class GetStarFromIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var star = (int)value;

            switch (star)
            {
                case 1:
                    return "ion-android-star";

                case 2:
                    return "ion-android-star-half";

                default:
                    return "ion-android-star-outline";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
