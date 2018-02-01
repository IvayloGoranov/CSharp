using System.Windows;
using System.Windows.Input;

namespace CustomUserControlsDemo
{
    /// <summary>
    /// Interaction logic for UserControlsWindow.xaml
    /// </summary>
    public partial class UserControlsWindow : Window
    {
        public UserControlsWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
