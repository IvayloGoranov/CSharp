using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFormsRPNCalculator
{
    class CalculatorStack
    {
        private double[] _registers = new double[] { 0.0, 0.0, 0.0 };

        public void Push(double val)
        {
            _registers[2] = _registers[1];
            _registers[1] = _registers[0];
            _registers[0] = val;
        }

        public double Pop()
        {
            double temp = _registers[0];
            _registers[0] = _registers[1];
            _registers[1] = _registers[2];
            _registers[2] = 0.0;
            return temp;
        }

        public void Reset()
        {
            _registers[0] = _registers[1] = _registers[2] = 0.0;
        }

        public double[] ToArray()
        {
            return _registers;
        }

        public void FromArray(double[] values)
        {
            _registers[0] = values[0];
            _registers[1] = values[1];
            _registers[2] = values[2];
        }
    }
}
