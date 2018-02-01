using System.Windows;

using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.View
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();

            this.Loaded += this.MainWindow_Loaded;

            this.mainViewModel = mainViewModel;
            this.DataContext = this.mainViewModel;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.Load();
        }
    }
}
