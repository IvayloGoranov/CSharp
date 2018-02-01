using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace VideoPlayer.Classes
{
    public sealed class ContentMargin
    {
        public ContentMargin()
        {
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FrameworkElement;
            if (control == null)
            {
                return;
            }
            var newValue = e.NewValue;
            var newValueAsBrush =(Thickness) newValue;
            control.Margin = newValueAsBrush;
        }

        public static Thickness GetMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(MarginProperty);
        }

        public static void SetMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginProperty, value);
        }

        public static readonly DependencyProperty MarginProperty =
        DependencyProperty.RegisterAttached("Margin",
                                            typeof(Thickness),
                                            typeof(ContentMargin),
                                            new FrameworkPropertyMetadata(default(Thickness), new PropertyChangedCallback(OnPropertyChanged)));
    }
}