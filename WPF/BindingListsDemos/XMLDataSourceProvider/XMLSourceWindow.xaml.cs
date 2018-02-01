using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Xml;

namespace XMLDataSourceProvider
{
    /// <summary>
    /// Interaction logic for XMLSourceWindow.xaml
    /// </summary>
    public partial class XMLSourceWindow : Window
    {
        public XMLSourceWindow()
        {
            InitializeComponent();
        }

        ICollectionView GetFamilyView()
        {
            DataSourceProvider provider =
                     (DataSourceProvider)this.FindResource("Family");
            return CollectionViewSource.GetDefaultView(provider.Data);
        }

        private void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            XmlElement person = (XmlElement)view.CurrentItem;
            person.SetAttribute("Age",
              (int.Parse(person.Attributes["Age"].Value) + 1).ToString());
            MessageBox.Show(
              string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Attributes["Name"].Value,
                person.Attributes["Age"].Value),
              "Birthday");
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

        private void buttonSort_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            if (view.SortDescriptions.Count == 0)
            {
                view.SortDescriptions.Add(
                  new SortDescription("@Age", ListSortDirection.Ascending));
                view.SortDescriptions.Add(
                  new SortDescription("@Name", ListSortDirection.Descending));
            }
            else
            {
                view.SortDescriptions.Clear();
            }
        }

        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            if (view.Filter == null)
            {
                view.Filter = delegate(object item)
                {
                    return
                      int.Parse(((XmlElement)item).Attributes["Age"].Value) > 25;
                };
            }
            else
            {
                view.Filter = null;
            }
        }
    }
    
}
