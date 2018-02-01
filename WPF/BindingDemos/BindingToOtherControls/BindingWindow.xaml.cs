using System.Windows;
using System.Windows.Media;

namespace BindingToOtherControls
{
    public partial class BindingWindow : Window
    {
        Person person = new Person("Dedo Kolio", 200);

        public BindingWindow()
        {
            InitializeComponent();
            grid.DataContext = person;
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ++person.Age;
            MessageBox.Show(string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name, person.Age), "Birthday");
            this.ageTextBox.Foreground = Brushes.Yellow;
        }
    }
}
