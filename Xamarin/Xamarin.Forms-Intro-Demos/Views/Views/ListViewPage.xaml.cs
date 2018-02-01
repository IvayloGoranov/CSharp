using System;

using Xamarin.Forms;

namespace Views
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            this.InitializeComponent();

            Person[] people = {
                new Person {
                    Name = "Pesho",
                    DOB = new DateTime(1984, 10, 01),
                    Color = Color.Blue
                },
                new Person {
                    Name = "Gosho",
                    DOB = new DateTime(1980, 10, 01),
                    Color = Color.Aqua
                }
            };

            this.listViewPeople.ItemsSource = people;
        }
    }
}
