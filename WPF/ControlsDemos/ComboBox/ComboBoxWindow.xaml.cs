using System.Windows;

namespace ComboBox
{
    /// <summary>
    /// Interaction logic for ComboBoxWindow.xaml
    /// </summary>
    public partial class ComboBoxWindow : Window
    {
        public ComboBoxWindow()
        {
            InitializeComponent();
            ComboBoxPeople.SelectedIndex = 0;
        }
    }
}
