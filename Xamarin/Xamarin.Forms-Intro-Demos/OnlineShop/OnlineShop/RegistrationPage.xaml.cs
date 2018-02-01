using System;

using Xamarin.Forms;

namespace OnlineShop
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        protected void OnUsernameTextChanged(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            this.labelUsername.Text = entry.Text;
        }

        protected void OnPasswordUnfocused(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            this.labelPassword.Text = entry.Text;
        }

        protected void OnButtonClicked(object sender, EventArgs e)
        {
        }
    }
}
