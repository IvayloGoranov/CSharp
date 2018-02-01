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

namespace DataTemplateTriggers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person person = new Person("Dedo Kolio", 200);
        private List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            people.Add(person);
            people.Add(new Person("Pesho", 20));
            people.Add(new Person("Pesho", 21));

            this.gridMain.DataContext = people;
        }

        void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            // Data binding keeps person and the text boxes synchronized
            ++person.Age;
            //MessageBox.Show(string.Format(
            //    "Happy Birthday, {0}, age {1}!",
            //    person.Name, person.Age), "Birthday");

            //this.birthdayButton.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
    }
}
