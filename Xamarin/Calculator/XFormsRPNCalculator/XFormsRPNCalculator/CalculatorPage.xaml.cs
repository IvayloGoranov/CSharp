using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFormsRPNCalculator
{
    public partial class CalculatorPage : ContentPage
    {
		private double _width = 0.0;
		private double _height = 0.0;

		public CalculatorPage()
        {
            InitializeComponent();
            this.BindingContext = ((App)Application.Current).GetCalculatorViewModel();
        }

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height); // Important!

			if (width != _width || height != _height)
			{
				_width = width;
				_height = height;
				ShowExtraButtons(width > height);
            }
		}

		private void ShowExtraButtons(bool visible)
		{
			foreach (View child in LayoutRoot.Children)
			{
				if (child is Button && (int)child.GetValue(Grid.ColumnProperty) < 2)
				{
					child.IsVisible = visible;
				}
			}
		}
    }
}
