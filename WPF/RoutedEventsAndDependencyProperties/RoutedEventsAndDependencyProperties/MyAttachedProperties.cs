using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RoutedEventsAndDependencyProperties
{
    public static class MyAttachedProperties
    {
        public static int GetVolume(DependencyObject obj)
        {
            return (int)obj.GetValue(VolumeProperty);
        }

        public static void SetVolume(DependencyObject obj, int value)
        {
            obj.SetValue(VolumeProperty, value);
        }

        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.RegisterAttached("Volume", typeof(int), 
                typeof(MyAttachedProperties), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.Inherits));


    }
}
