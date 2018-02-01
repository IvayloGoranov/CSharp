using System;

public class NotCheckedException : ApplicationException
{
    public NotCheckedException(string message)
        : base(message)
    {
    }
}
