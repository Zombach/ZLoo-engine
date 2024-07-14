using FluentAssertions;
using Models.Exceptions;

namespace Models.Tests.Exceptions;

public class TestExceptionTests
{
    [Fact]
    public void Ctor_Ok()
    {
        const string dummy = "dummy";
        var exception = new InvalidOperationException();

        new TestException().Message.Should().Be("Test message");
        new TestException(dummy).Message.Should().Be(dummy);

        var test = new TestException(dummy, exception);
        test.Message.Should().Be(dummy);
        test.InnerException.Should().Be(exception);
    }
}
