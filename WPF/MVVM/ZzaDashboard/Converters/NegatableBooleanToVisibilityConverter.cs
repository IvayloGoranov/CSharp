using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZzaDashboard.Converters
{
    public class NegatableBooleanToVisibilityConverter : IValueConverter
    {
        public NegatableBooleanToVisibilityConverter()
        {
            this.FalseVisibility = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue;
            bool result = bool.TryParse(value.ToString(), out bValue);
            if (!result)
            {
                return value;
            }

            if (bValue && !Negate)
            {
                return Visibility.Visible;
            }

            if (bValue && Negate)
            {
                return FalseVisibility;
            }

            if (!bValue && Negate)
            {
                return Visibility.Visible;
            }

            if (!bValue && !Negate)
            {
                return FalseVisibility;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Visibility FalseVisibility { get; set; }

        public bool Negate { get; set; }
    }
}
