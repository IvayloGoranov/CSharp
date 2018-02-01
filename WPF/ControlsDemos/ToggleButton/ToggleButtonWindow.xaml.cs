using System.Windows;

namespace ToggleButton
{
    /// <summary>
    /// Interaction logic for ToggleButtonWindow.xaml
    /// </summary>
    public partial class ToggleButtonWindow : Window
    {
        public ToggleButtonWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Toggle button IsChecked state : " + myToggleButton.IsChecked.Value.ToString());
        }
    }
}
