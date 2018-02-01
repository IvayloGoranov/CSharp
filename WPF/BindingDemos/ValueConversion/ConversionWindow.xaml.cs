using System.Windows;

namespace ValueConversion
{
    public partial class ConversionWindow : Window
    {
        Person person = new Person("Jorko", 24);

        public ConversionWindow()
        {
            InitializeComponent();
            grid.DataContext = person;
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ++person.Age;
            ageTextBox.Text = person.Age.ToString();
            ageTextBox.Focus();
            MessageBox.Show(string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name, person.Age), "Birthday");
        }
    }
}
