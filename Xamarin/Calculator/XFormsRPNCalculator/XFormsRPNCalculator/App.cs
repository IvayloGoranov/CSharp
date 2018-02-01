using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

using Xamarin.Forms;

namespace XFormsRPNCalculator
{
    public class App : Application
    {
        private const string _key = "CalculatorState";
        private CalculatorViewModel _cvm = new CalculatorViewModel();

        public App()
        {
            this.MainPage = new CalculatorPage();
        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey(_key))
            {
                string state = (string)Application.Current.Properties[_key];
                _cvm.SetState(Deserialize<CalculatorState>(state));
            }
        }

        protected override void OnSleep()
        {
            string state = Serialize<CalculatorState>(_cvm.GetState());
            Application.Current.Properties[_key] = state;
        }

        public CalculatorViewModel GetCalculatorViewModel()
        {
            return _cvm;
        }

        private string Serialize<T>(Object o)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, o);
                return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            }
        }

        private T Deserialize<T>(string s)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(s)))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}