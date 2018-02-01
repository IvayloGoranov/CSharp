namespace mUnit.Core.Attributes
{
    using System;

    public class ShouldThrowAttribute : Attribute
    {
        public ShouldThrowAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }

        public Type ExceptionType { get; private set; }
    }
}
