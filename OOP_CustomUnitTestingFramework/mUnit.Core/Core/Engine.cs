namespace mUnit.Core.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Interfaces;
    using TestRunners;

    public class Engine
    {
        private readonly string assemblyPath;

        public Engine(string assemblyPath, IOutputWriter writer)
        {
            this.assemblyPath = assemblyPath;
            this.OutputWriter = writer;
        }

        public IOutputWriter OutputWriter { get; private set; }

        public void Run()
        {
            var assemblyLoader = new AssemblyLoader(this.assemblyPath);
            var assembly = assemblyLoader.Assembly;
            
            var testMethodLoader = new TestMethodLoader(assembly);
            var testContainers = testMethodLoader.LoadTestMethods();
            foreach (var testContainer in testContainers)
            {
                var instance = Activator.CreateInstance(testContainer.Key);
                var testMethods = testContainer.Value;
                foreach (MethodInfo testMethod in testMethods)
                {
                    var testType = this.GetTestType(testMethod);

                    var testRunner = TestRunnerFactory.GetTestRunner(
                        testType,
                        testMethod,
                        instance);

                    testRunner.RunTest();
                    this.LogTestResult(testRunner, testMethod);
                }
            }
        }

        private void LogTestResult(TestRunner testRunner, MethodInfo testMethod)
        {
            switch (testRunner.TestResult)
            {
                case TestResult.Passed:
                    this.OutputWriter.Write(
                        string.Format(
                            "Test {0} passed!",
                            testMethod.Name));
                    break;
                case TestResult.Failed:
                    this.OutputWriter.Write(
                        string.Format(
                            "Test {0} failed. Reason: {1}",
                            testMethod.Name,
                            testRunner.FailReason));
                    break;
                case TestResult.Skipped:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException("TestResult not supported");
            }
        }

        private TestType GetTestType(MethodInfo testMethod)
        {
            var uniqueAttributeTypes = new HashSet<TestType>();
            foreach (Attribute attr in testMethod.GetCustomAttributes())
            {
                switch (attr.GetType().Name)
                {
                    case "TestAttribute":
                        uniqueAttributeTypes.Add(TestType.Normal);
                        break;
                    case "ShouldThrowAttribute":
                        uniqueAttributeTypes.Add(TestType.ShouldThrow);
                        break;
                    case "TestCaseAttribute":
                        uniqueAttributeTypes.Add(TestType.TestCases);
                        break;
                }
            }

            if (uniqueAttributeTypes.Contains(TestType.ShouldThrow) &&
                uniqueAttributeTypes.Contains(TestType.TestCases))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Method cannot have {0} and {1} attributes at the same time",
                        TestType.ShouldThrow,
                        TestType.TestCases));
            }
            else if (uniqueAttributeTypes.Contains(TestType.TestCases))
            {
                return TestType.TestCases;
            }
            else if (uniqueAttributeTypes.Contains(TestType.ShouldThrow))
            {
                return TestType.ShouldThrow;
            }
            else
            {
                return TestType.Normal;
            }
        }
    }
}
