using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;

namespace BindingLists
{
    public partial class PathWindow : Window
    {
        public PathWindow()
        {
            InitializeComponent();
        }

        ICollectionView GetFamilyView()
        {
            People people = (People)this.FindResource("Family");
            return CollectionViewSource.GetDefaultView(people);
        }

        private void BirthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            Person person = (Person)view.CurrentItem;
            ++person.Age;
            MessageBox.Show(string.Format("Happy Birthday, {0}, age {1}!", 
                person.Name, person.Age), "Birthday");
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToLast();
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToFirst();
            }
        }
        
        private void ListBoxPeople_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            int index = ListBoxPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            Person item = (Person)ListBoxPeople.SelectedItem;
            int value = (int)ListBoxPeople.SelectedValue;
            MessageBox.Show(string.Format("Name:  {0}, Age:  {1}!", 
                item.Name, value), "Selected Item");
        }
    }
}
