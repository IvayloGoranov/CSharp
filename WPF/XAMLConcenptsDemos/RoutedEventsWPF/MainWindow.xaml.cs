using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEventsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Bubbling routes:
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockBubbling.Text += "Clicked from TextBlock\n";
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockBubbling.Text += "Clicked from Grid\n";
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockBubbling.Text += "Clicked from StackPanel\n";
        }

        private void ScrollViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockBubbling.Text += "Clicked from ScroolViewer\n";
        }


        #endregion
        #region Tunelling routes:



        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockTunelling.Text += "Clicked from TextBlock\n";
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockTunelling.Text += "Clicked from StackPanel\n";
        }

        private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockTunelling.Text += "Clicked from ScroolViewer\n";
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlockTunelling.Text += "Clicked from Grid\n";
        }
        #endregion
    }
}