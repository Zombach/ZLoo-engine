using FluentAssertions;
using LocalizationService.Models.SourceXml;

namespace LocalizationService.Tests.Models.SourceXml;

public class ItemTests
{
    [Fact]
    public void Should_throw_when_key_setter_value_is_null()
    {
        var item = new Item();
        string value = null!;
        const string expected = "value";

        Action action = () => item.Value = value;
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }

    [Fact]
    public void Should_throw_when_value_setter_value_is_null()
    {
        var item = new Item();
        string key = null!;
        const string expected = "value";

        Action action = () => item.Key = key;
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
