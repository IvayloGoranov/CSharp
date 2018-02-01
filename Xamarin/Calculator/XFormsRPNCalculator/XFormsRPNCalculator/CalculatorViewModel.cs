using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFormsRPNCalculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Calculator _calc = new Calculator();

        public string Output
        {
            get { return _calc.Output; }
            set
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Output"));
            }
        }

        public ICommand CalculatorCommand
        {
            get { return new CalculatorCommand(this); }
        }

        public void Execute(string command)
        {
            _calc.Execute(command);
            this.Output = _calc.Output;
        }

        public void SetState(CalculatorState state)
        {
            _calc.SetCalculatorState(state);
            this.Output = _calc.Output;
        }

        public CalculatorState GetState()
        {
            return _calc.GetCalculatorState();
        }
    }
}
