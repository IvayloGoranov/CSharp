using System;
using System.Windows.Input;

namespace RelayCommandExample.Helper
{
    internal class RelayCommandParameter : ICommand
    {
        private readonly Action<object> _command;
        private readonly Predicate<object> _canExecute;

        public RelayCommandParameter(Action<object> command, Predicate<object> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            _canExecute = canExecute;
            _command = command;
        }

        public void Execute(object parameter)
        {
            _command(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}