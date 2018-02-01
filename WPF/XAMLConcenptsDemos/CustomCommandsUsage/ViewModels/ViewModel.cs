using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using CustomCommandsUsage.Commands;

namespace CustomCommandsUsage.ViewModels
{
    public class ViewModel:INotifyPropertyChanged
    {
        private ICommand messageCommand;
        public ICommand MessageCommand
        {
            get
            {
                if (this.messageCommand == null)
                {
                    this.messageCommand = new MessagePopCommand(this);
                }
                return this.messageCommand;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void SetText(object parameter)
        {
            this.TextToShow = parameter.ToString();
        }

        private string text;


        public string TextToShow
        {
            get
            {
                return this.text;
            }
            private set
            {
                this.text = value;
                OnPropertyChanged("TextToShow");
            }
        }
    }
}
