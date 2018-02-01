using System.Windows;
using System.Windows.Controls;

namespace DataContexts
{
    public partial class DataContextsWindow : Window
    {
        Person person = new Person("Dedo Kolio", 200);

        public DataContextsWindow()
        {
            InitializeComponent();
            GridMain.DataContext = person;
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            // Data binding keeps person and the text boxes synchronized
            ++person.Age;
            MessageBox.Show(string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name, person.Age), "Birthday");

            //this.birthdayButton.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
    }
}
