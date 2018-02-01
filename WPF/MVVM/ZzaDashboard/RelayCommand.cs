using System;
using System.Windows.Input;

namespace ZzaDashboard
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = delegate { };

        private Action TargetExecuteMethod;
        private Func<bool> TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            this.TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.TargetExecuteMethod = executeMethod;
            this.TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (this.TargetCanExecuteMethod != null)
            {
                return this.TargetCanExecuteMethod();
            }

            if (this.TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (this.TargetExecuteMethod != null)
            {
                this.TargetExecuteMethod();
            }
        }
    }


    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged = delegate { };

        private Action<T> TargetExecuteMethod;
        private Func<T, bool> TargetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            this.TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            this.TargetExecuteMethod = executeMethod;
            this.TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (this.TargetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;

                return this.TargetCanExecuteMethod(tparm);
            }

            if (this.TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (this.TargetExecuteMethod != null)
            {
                this.TargetExecuteMethod((T)parameter);
            }
        }
    }
}
