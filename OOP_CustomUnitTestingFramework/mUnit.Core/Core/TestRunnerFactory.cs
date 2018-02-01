using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mUnit.Core.Core
{
    using System.Reflection;
    using TestRunners;

    public enum TestType
    {
        Normal,
        ShouldThrow,
        TestCases
    }

    public class TestRunnerFactory
    {
        public static TestRunner GetTestRunner(
            TestType type, 
            MethodInfo testMethod, 
            object typeInstance)
        {
            switch (type)
            {
                case TestType.Normal:
                    return new NormalTestRunner(testMethod, typeInstance);
                case TestType.ShouldThrow:
                    return new ShouldThrowTestRunner(testMethod, typeInstance);
                case TestType.TestCases:
                    return new TestCaseRunner(testMethod, typeInstance);
                default:
                    throw new NotSupportedException("Test type has no supported runner at this moment");
            }
        }
    }
}
