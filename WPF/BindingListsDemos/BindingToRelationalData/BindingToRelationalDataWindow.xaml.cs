using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BindingToRelationalData
{
    public partial class BindingToRelationalDataWindow : Window
    {
        DataClassesPeopleDataContext dataContextPeople;

        public BindingToRelationalDataWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPeople();
        }

        private void LoadPeople()
        {
            dataContextPeople = new DataClassesPeopleDataContext();
            this.DataContext = dataContextPeople.Peoples;
            this.TextBoxAdd.Text = null;
            this.TextBoxEdit.Text = null;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            People selectedPerson = (People)ListBoxPeople.SelectedItem;
            if (selectedPerson != null)
            {
                dataContextPeople.Peoples.DeleteOnSubmit(selectedPerson);
                dataContextPeople.SubmitChanges();
                LoadPeople();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAdd.Text.Length > 0)
            {
                People newPerson = new People();
                newPerson.PersonName = TextBoxAdd.Text;
                dataContextPeople.Peoples.InsertOnSubmit(newPerson);
                dataContextPeople.SubmitChanges();
                LoadPeople();
            }
        }

        private void ListBoxPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           People selectedPerson = (People)ListBoxPeople.SelectedItem;
           if (selectedPerson != null)
           {
               this.TextBoxEdit.Text = selectedPerson.PersonName;
           }
           else
           {
               this.TextBoxEdit.Text = null;
           }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            People selectedPerson = (People)ListBoxPeople.SelectedItem;
            if (selectedPerson != null)
            {
                selectedPerson.PersonName = this.TextBoxEdit.Text;
                dataContextPeople.SubmitChanges();
                LoadPeople();
            }
        }
    }
}
