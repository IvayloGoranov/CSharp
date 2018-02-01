namespace mUnit.Core.Exceptions
{
    using System;

    public class AssertFailedException : Exception
    {
        public AssertFailedException(string msg)
            : base(msg)
        {
        }
    }
}
