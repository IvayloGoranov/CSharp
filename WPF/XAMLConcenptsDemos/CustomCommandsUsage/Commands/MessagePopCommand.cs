using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using CustomCommandsUsage.ViewModels;

namespace CustomCommandsUsage.Commands
{
    class MessagePopCommand:ICommand
    {
        ViewModel viewModel;
        public MessagePopCommand(ViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }

            return !string.IsNullOrEmpty(parameter.ToString());
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.viewModel.SetText(parameter);
        }
    }
}
