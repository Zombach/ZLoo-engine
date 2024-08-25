using FluentAssertions;

namespace JsonConverterService.Tests;

public class JsonConverterProviderTests
{
    private class TestConverter : JsonConverterProvider<string[]>;

    [Fact]
    public void Should_throw_for_to_json_when_model_is_null()
    {
        var testConverter = new TestConverter();
        string[] model = null!;

        var action = () => testConverter.ToJson(model);

        var exception = action.Should().Throw<ArgumentNullException>();
        exception.And.ParamName.Should().Be(nameof(model));
    }

    [Fact]
    public void Should_throw_for_to_model_when_json_is_null()
    {
        var testConverter = new TestConverter();
        string json = null!;

        var action = () => testConverter.ToModel(json);

        var exception = action.Should().Throw<ArgumentNullException>();
        exception.And.ParamName.Should().Be(nameof(json));
    }
}
