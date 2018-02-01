using System.Collections.Generic;
using System.Windows;

namespace ComplexBinding
{
    public partial class ComplexBindingWindow : Window
    {
        public ComplexBindingWindow()
        {
            InitializeComponent();
        }

        private void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> family = this.Resources["Family"] as List<Person>;
            family[0].Age++;

            // Manually rebind the grid
            this.grid.DataContext = null;
            this.grid.DataContext = family;
        }
    }
}
