using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XFormsRPNCalculator
{
    class CalculatorCommand : ICommand
    {
        private CalculatorViewModel _vm;

        public event EventHandler CanExecuteChanged;

        public CalculatorCommand(CalculatorViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.Execute((string)parameter);
        }
    }
}
