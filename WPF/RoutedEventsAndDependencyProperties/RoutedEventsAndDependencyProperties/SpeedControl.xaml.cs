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
    /// Interaction logic for SpeedControl.xaml
    /// </summary>
    public partial class SpeedControl : UserControl
    {
        public SpeedControl()
        {
            InitializeComponent();
        }

        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(int), 
                typeof(SpeedControl), 
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                    OnSpeedChanged, null, false, UpdateSourceTrigger.LostFocus));

        private static void OnSpeedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpeedControl)d).SpeedInput.Text = e.NewValue.ToString();
        }

        private void OnSpeedInputChanged(object sender, TextChangedEventArgs e)
        {
            if (SpeedInput.IsFocused)
            {
                int val;
                bool success = int.TryParse(SpeedInput.Text, out val);
                if (success) Speed = val;
            }
        }
    }
}
