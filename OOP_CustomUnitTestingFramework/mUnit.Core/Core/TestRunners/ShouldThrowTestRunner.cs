using System;

namespace mUnit.Core.Core.TestRunners
{
    using System.Linq;
    using System.Reflection;
    using Attributes;

    public class ShouldThrowTestRunner : TestRunner
    {
        private const string FailMessageOutput = "Expected exception {0} was not thrown";

        public ShouldThrowTestRunner(
            MethodInfo methodInfo,
            object typeInstance) 
            : base(methodInfo, typeInstance)
        {
            // TODO: Validate method attributes
        }

        public override void RunTest()
        {
            var throwAttribute = (ShouldThrowAttribute)this.TestMethod.GetCustomAttributes()
                   .First(a => a is ShouldThrowAttribute);
            var expectedExceptionType = throwAttribute.ExceptionType;
            var message = string.Format(
                    FailMessageOutput,
                    expectedExceptionType.Name);

            try
            {
                this.TestMethod.Invoke(this.TypeInstance, null);
                this.SetFailResult(message);
            }
            catch (Exception catchedEx)
            {
                if (catchedEx.InnerException.GetType().Name == expectedExceptionType.Name)
                {
                    this.TestResult = TestResult.Passed;
                }
                else
                {
                    this.SetFailResult(message);
                }
            }
        }
    }
}
