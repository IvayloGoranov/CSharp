using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EventRouting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.MouseEnter += MouseEnterHandler;
            //this.myBorder.MouseEnter += MouseEnterHandler;
            //this.myPanel.MouseEnter += MouseEnterHandler;
            //this.myEllipse.MouseEnter += MouseEnterHandler;
            //this.myRectangle.MouseEnter += MouseEnterHandler;

            this.MouseDown += MouseDownHandler;
            this.myBorder.MouseDown += MouseDownHandler;
            this.myPanel.MouseDown += MouseDownHandler;
            this.myEllipse.MouseDown += MouseDownHandler;
            this.myRectangle.MouseDown += MouseDownHandler;

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                btn.Content = "Button" + i;
                this.myPanel.Children.Add(btn);

                //btn.Click += new RoutedEventHandler(Button_Click);
            }

            this.myPanel.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            button.Background = Brushes.Green;
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("MouseDown: " + sender);
        }

        private void MouseEnterHandler(object sender, MouseEventArgs e)
        {
            MessageBox.Show("MouseEnter: " + sender);
        }
    }
}
