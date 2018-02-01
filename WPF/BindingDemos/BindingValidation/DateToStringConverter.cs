using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace BindingValidation
{
    public class DateToStringConverter : IValueConverter
    {
        public string DateFormat { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            string dateStr = date.ToString(this.DateFormat, culture);
            return dateStr;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            DateTime date = DateTime.ParseExact((string)value, this.DateFormat, culture);
            return date;
        }
    }
}
