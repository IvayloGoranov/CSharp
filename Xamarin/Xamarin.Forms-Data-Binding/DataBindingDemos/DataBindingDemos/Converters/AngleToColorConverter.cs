using System;
using Xamarin.Forms;
using System.Globalization;

namespace DataBindingDemos.Converters
{
    public class AngleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            double val = (double)value / 360;

            return Color.FromRgb(val, 0, 1 - val);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
