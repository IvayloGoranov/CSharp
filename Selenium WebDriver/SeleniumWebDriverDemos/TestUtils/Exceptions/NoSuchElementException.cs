using System;

public class NoSuchElementException : ApplicationException
{
    public NoSuchElementException(string message, Exception ex)
        : base(message, ex)
    {
    }
}
