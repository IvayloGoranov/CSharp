using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Contacts;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Util;

using DeviceAPIs;

[assembly: Dependency(typeof(DeviceAPIs.Droid.ContactsGetter_Android))]
namespace DeviceAPIs.Droid
{
    [Activity(Label = "ContactsGetter")]
    public class ContactsGetter_Android : Activity, IContactsGetter
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        public async void GetPhonebook()
        {
            try
            {
                var addressBook = new AddressBook(Forms.Context);
                bool hasAccess = await addressBook.RequestPermission();

                if (hasAccess)
                {
                    List<AppContact> contacts = new List<AppContact>();
                    foreach (var contact in addressBook)
                    {
                        contacts.Add(new AppContact
                        {
                            Name = contact.DisplayName,
                            Number = contact.Phones.FirstOrDefault().Number
                        });
                    }

                    MessagingCenter.Send<IContactsGetter, IEnumerable<AppContact>>(this, "gotContacts", contacts);
                } 
            }
            catch (Exception e)
            {
                Log.Debug("Contactsgetter Error", e.ToString());
            }
        }
    }
}