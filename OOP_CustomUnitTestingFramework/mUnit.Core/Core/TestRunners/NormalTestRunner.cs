using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mUnit.Core.Core.TestRunners
{
    using System.Reflection;

    public class NormalTestRunner : TestRunner
    {
        public NormalTestRunner(
            MethodInfo methodInfo, 
            object typeInstance)
            : base(methodInfo, typeInstance)
        {
        }

        public override void RunTest()
        {
            try
            {
                this.TestMethod.Invoke(this.TypeInstance, null);
                this.TestResult = TestResult.Passed;
            }
            catch (Exception ex)
            {
                this.SetFailResult(ex.InnerException.Message);
            }
        }
    }
}
