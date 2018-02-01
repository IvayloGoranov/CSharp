using System;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public partial class ListViewTemplatingPage : ContentPage
    {
        public ListViewTemplatingPage()
        {
            InitializeComponent();

            this.listView.ItemsSource = new[]
            {
                new { Name = "Pesho", Description = "I am Pesho"},
                new { Name = "Gosho", Description = "I am Gosho"}
            };
        }

        protected void OnItemSelected(object sender, EventArgs e)
        {

        }
    }
}
