using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PagesDemos
{
    public class TabbedPageDemo : TabbedPage
    {
        private NamedColor[] namedColors;
        private ListView listView;

        public TabbedPageDemo(NamedColor[] namedColors)
        {
            this.Title = "Tabbed Page";
            this.namedColors = namedColors;
            this.ItemsSource = this.namedColors;

            this.ItemTemplate = new DataTemplate(() => {
                return new NamedColorPage();
            });
        }
    }
}
