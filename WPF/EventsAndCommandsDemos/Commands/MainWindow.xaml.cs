using System;
using System.Windows;
using System.Windows.Input;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy);
            this.CommandBindings.Add(copyCommand);
            copyCommand.Executed += new ExecutedRoutedEventHandler(CopyCommand_Executed);
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Copy command executed");
        }
    }
}
