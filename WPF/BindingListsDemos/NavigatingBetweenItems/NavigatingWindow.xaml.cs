using System.Windows;
using System.Windows.Data;
using System.ComponentModel;

namespace NavigatingBetweenItems
{
    public partial class NavigatingWindow : Window
    {
        public NavigatingWindow()
        {
            InitializeComponent();
        }

        ICollectionView GetFamilyView()
        {
            People people = (People)this.FindResource("Family");
            return CollectionViewSource.GetDefaultView(people);
        }

        private void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            Person person = (Person)view.CurrentItem;
            ++person.Age;
            MessageBox.Show(string.Format("Happy Birthday, {0}, age {1}!",
                person.Name, person.Age), "Birthday");
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
        }

        private void buttonForward_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
        }
    }
}
