using System;
using System.Windows.Input;

namespace RelayCommandExample.Helper
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _command;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action command, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            _canExecute = canExecute;
            _command = command;
        }

        public void Execute(object parameter)
        {
            _command();
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}