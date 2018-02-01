namespace mUnit.Core.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseAttribute : Attribute
    {
        public TestCaseAttribute(object param)
        {
            this.Param = param;
        }

        public object Param { get; private set; }
    }
}
