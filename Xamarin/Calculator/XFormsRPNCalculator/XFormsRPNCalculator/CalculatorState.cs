using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XFormsRPNCalculator
{
    [DataContract]
    public class CalculatorState
    {
        [DataMember]
        public string Output { get; set; }
        [DataMember]
        public string Format { get; set; }
        [DataMember]
        public bool IsNewPending { get; set; }
        [DataMember]
        public bool IsFixPending { get; set; }
        [DataMember]
        public double Memory { get; set; }
        [DataMember]
        public double XRegister { get; set; }
        [DataMember]
        public double[] Stack { get; set; }
    }
}
