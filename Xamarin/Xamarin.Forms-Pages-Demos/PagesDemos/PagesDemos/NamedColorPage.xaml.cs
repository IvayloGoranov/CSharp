using Xamarin.Forms;

namespace PagesDemos
{
    public partial class NamedColorPage : ContentPage
    {
        public NamedColorPage()
        {
            this.InitializeComponent();
        }

        public NamedColorPage(NamedColor namedColor)
        {
            this.InitializeComponent();

            this.BindingContext = namedColor;
        }
    }
}
