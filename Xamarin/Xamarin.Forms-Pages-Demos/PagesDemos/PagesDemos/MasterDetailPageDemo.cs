using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PagesDemos
{
    public class MasterDetailPageDemo : MasterDetailPage
    {
        private NamedColor[] namedColors;
        private ListView listView;

        public MasterDetailPageDemo(NamedColor[] namedColors)
        {
            this.namedColors = namedColors;
            this.listView = new ListView
            {
                ItemsSource = this.namedColors
            };
            this.Master = new ContentPage
            {
                Content = this.listView,
                Title = "Master Page"
            };

            this.Detail = new NavigationPage(new NamedColorPage());
            this.Detail.BindingContext = this.namedColors[0];
            this.IsPresented = true;

            this.listView.ItemSelected += OnListViewItemSelected;
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Detail.BindingContext = e.SelectedItem;
            this.IsPresented = false;
        }
    }
}
