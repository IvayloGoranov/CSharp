using System;
using Xamarin.Forms;

using Phoneword.Core;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        private string translatedNumber;
        private IPhonewordTranslator translator;

        public MainPage(IPhonewordTranslator translator)
        {
            this.translator = translator;

            this.InitializeComponent();
        }

        protected void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = this.translator.ToNumber(this.phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                this.callButton.IsEnabled = true;
                this.callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                this.callButton.IsEnabled = false;
                this.callButton.Text = "Call";
            }
        }

        protected async void OnCall(object sender, EventArgs e)
        {
            bool isDisplayAlertAccepted = await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No");

            if (isDisplayAlertAccepted)
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    App.PhoneNumbers.Add(translatedNumber);
                    this.callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
                }
            }
        }

        protected async void OnCallHistory(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new CallHistoryPage());
        }
    }
}
