using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEventsAndDependencyProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDirtyChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (e.NewValue)
            {
                Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                Background = new SolidColorBrush(Colors.White);
            }
        }



        public int SpeedModelValue
        {
            get { return (int)GetValue(SpeedModelValueProperty); }
            set { SetValue(SpeedModelValueProperty, value); }
        }

        public static readonly DependencyProperty SpeedModelValueProperty =
            DependencyProperty.Register("SpeedModelValue", typeof(int), 
                typeof(MainWindow), new PropertyMetadata(0));


    }
}
