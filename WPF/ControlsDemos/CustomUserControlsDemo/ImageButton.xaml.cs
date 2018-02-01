using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomUserControlsDemo
{
    /// <summary>
    /// Interaction logic for ImageButton.xaml
    /// </summary>
    public partial class ImageButton : UserControl
    {
        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageButton));

        public ImageButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
