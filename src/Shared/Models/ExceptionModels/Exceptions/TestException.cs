using System;

namespace ExceptionModels.Exceptions;

public class TestException : Exception
{
    public TestException()
        : base("Test message")
    {

    }

    public TestException(string message)
        : base(message)
    {

    }

    public TestException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}
