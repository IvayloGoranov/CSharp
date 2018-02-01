using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace XAMLDrawingModel
{
    /// <summary>
    /// Interaction logic for DrawingWindow.xaml
    /// </summary>
    public partial class DrawingWindow : Window
    {
        public DrawingWindow()
        {
            InitializeComponent();
        }

        private void CanvasMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle selectedRectangle = e.Source as Rectangle;
            //Rectangle selectedRectangle = CanvasMain.FindName("FirstRectangle") as Rectangle;
            //Rectangle selectedRectangle = FirstRectangle as Rectangle;
            if (selectedRectangle != null)
            {
                selectedRectangle.Width += 10;
            }
        }
    }
}
