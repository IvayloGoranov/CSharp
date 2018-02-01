using System;

public class StillCheckedException : ApplicationException
{
    public StillCheckedException(string message)
        : base(message)
    {
    }
}