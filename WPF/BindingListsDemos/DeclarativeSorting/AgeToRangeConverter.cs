using System.Windows.Data;
using System;

namespace DeclarativeSorting
{
    public class AgeToRangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value < 25 ? "Under the Hill" : "Over the Hill";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
