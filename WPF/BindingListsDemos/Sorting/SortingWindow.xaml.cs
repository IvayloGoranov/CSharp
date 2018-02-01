using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;

namespace Sorting
{
    /// <summary>
    /// Interaction logic for SortingWindow.xaml
    /// </summary>
    public partial class SortingWindow : Window
    {
        public SortingWindow()
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
            People people = (People)this.FindResource("Family");
            ICollectionView view =
            CollectionViewSource.GetDefaultView(people);
            Person person = (Person)view.CurrentItem;
            ++person.Age;
            MessageBox.Show(string.Format("Happy Birthday, {0}, age {1}!", person.Name, person.Age), "Birthday");
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
        }

        private void ListBoxPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = ListBoxPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Person item = (Person)ListBoxPeople.SelectedItem;
            int value = (int)ListBoxPeople.SelectedValue;
            MessageBox.Show(string.Format("Name:  {0}, Age:  {1}!", item.Name, value));
        }

        private void ButtonSort_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            if (view.SortDescriptions.Count == 0)
            {
                view.SortDescriptions.Add(
                    new SortDescription("Name", ListSortDirection.Ascending));
                view.SortDescriptions.Add(
                    new SortDescription("Age", ListSortDirection.Descending));
            }
            else
            {
                view.SortDescriptions.Clear();
            }
        }
    }
}
