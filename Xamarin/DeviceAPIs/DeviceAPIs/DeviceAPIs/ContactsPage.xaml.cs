using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DeviceAPIs
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            this.listViewContacts.ItemsSource = new AppContact[]
                {
                    new AppContact { Name = "Pesho", Number = "09991111111"},
                    new AppContact { Name = "Gosho", Number = "09992222222"}
                };
        }

        public void Contacts_Clicked(object sender, EventArgs e)
        {
            var contactsGetter = DependencyService.Get<IContactsGetter>();
            if (contactsGetter == null)
            {
                return;
            }

            contactsGetter.GetPhonebook();

            MessagingCenter.Subscribe<IContactsGetter, IEnumerable<AppContact>>(this, 
                "gotContacts", DisplayContacts);
        }

        private void DisplayContacts(IContactsGetter sender, IEnumerable<AppContact> contacts)
        {
            this.listViewContacts.ItemsSource = contacts;
        }
    }
}
