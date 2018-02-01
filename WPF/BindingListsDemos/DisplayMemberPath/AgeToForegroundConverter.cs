﻿using System;
using System.Windows.Data;
using System.Windows.Media;

namespace BindingLists
{
    public class AgeToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Brush))
            {
                return null;
            }

            int age = int.Parse(value.ToString());

            return (age >= 25 ? Brushes.Red : Brushes.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
