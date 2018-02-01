using System;
using System.Windows.Input;
using RelayCommandExample.Helper;

namespace RelayCommandExample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {   
        private ICommand clickCommand;

        public ICommand ClickCommand
        { 
            get
            {
                if (this.clickCommand == null)
                {
                    this.clickCommand = new RelayCommandParameter(this.SomeMethod);
                }
                return this.clickCommand;
            }
        }

        public void SomeMethod(object parameter)
        {
            ShowMessageBox(parameter.ToString());
        }
    }
}