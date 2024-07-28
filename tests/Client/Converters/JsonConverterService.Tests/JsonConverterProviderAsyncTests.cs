using FluentAssertions;

namespace JsonConverterService.Tests;

public class JsonConverterProviderAsyncTests
{
    private class TestConverterAsync : JsonConverterProviderAsync<string[]>;

    [Fact]
    public async Task Should_throw_for_to_json_when_model_is_null()
    {
        var testConverterAsync = new TestConverterAsync();
        string[] model = null!;

        var action = async () => await testConverterAsync.ToJson(model, CancellationToken.None);

        var exception = await action.Should().ThrowAsync<ArgumentNullException>();
        exception.And.ParamName.Should().Be(nameof(model));
    }

    [Fact]
    public async Task Should_throw_for_to_model_when_json_is_null()
    {
        var testConverterAsync = new TestConverterAsync();
        Stream stream = null!;

        var action = async () => await testConverterAsync.ToModel(stream, CancellationToken.None);

        var exception = await action.Should().ThrowAsync<ArgumentNullException>();
        exception.And.ParamName.Should().Be(nameof(stream));
    }
}
