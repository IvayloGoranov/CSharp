using System;

using Xamarin.Forms;

namespace Views
{
    public partial class ButtonPage : ContentPage
	{
		public ButtonPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Text = "Clicked";
        }
    }
}
