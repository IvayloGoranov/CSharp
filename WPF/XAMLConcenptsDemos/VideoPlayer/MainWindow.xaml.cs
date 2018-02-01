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
using System.IO;

namespace VideoPlayer
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

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDiaglog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDiaglog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDiaglog.ShowDialog();
            string folderPath = folderBrowserDiaglog.SelectedPath;
            if (folderPath != string.Empty)
            {
                var files = Directory.GetFiles(folderPath).Where(file => file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("avi")).ToList<string>();
                this.VideoPlayer.ItemsSources = files;
            }
        }
    }
}