using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace ValueConversion
{
    public class AgeToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
            {
                return null; 
            }
            int age = int.Parse(value.ToString());
            return (age >= 25 ? Brushes.Red : Brushes.Black);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
