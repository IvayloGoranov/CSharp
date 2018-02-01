namespace mUnit.Core.Core.TestRunners
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Attributes;

    public class TestCaseRunner : TestRunner
    {
        public TestCaseRunner(
            MethodInfo methodInfo,
            object typeInstance)
            : base(methodInfo, typeInstance)
        {
        }

        public override void RunTest()
        {
            var allAttributes = this.TestMethod.GetCustomAttributes();
            var testCaseAttributes = new List<Attribute>();
            foreach (Attribute attribute in allAttributes)
            {
                if (attribute is TestCaseAttribute)
                {
                    testCaseAttributes.Add(attribute);
                }
            }

            int totalTests = testCaseAttributes.Count;
            int passedTests = 0;
            foreach (TestCaseAttribute attr in testCaseAttributes)
            {
                object param = attr.Param;
                try
                {
                    this.TestMethod.Invoke(
                        this.TypeInstance,
                        new object[] { param });
                    passedTests++;
                }
                catch (Exception ex)
                {
                    // TODO: Add exception message for output
                }
            }

            if (passedTests == totalTests)
            {
                this.TestResult = TestResult.Passed;
            }
            else
            {
                // TODO: Add exceptions to output as well
                this.SetFailResult(
                    string.Format(
                        "{0}/{1} failed",
                        totalTests - passedTests,
                        totalTests));
            }
        }
    }
}
