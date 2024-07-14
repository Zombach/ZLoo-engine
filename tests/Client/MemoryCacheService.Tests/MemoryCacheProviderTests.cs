using FluentAssertions;

namespace MemoryCacheService.Tests;

public class MemoryCacheProviderTests
{
    [Fact]
    public void Should_throw_when_cache_key_is_null()
    {
        const string expected = "cacheKey";

        var memoryCache = new MemoryCacheProvider<string>();
        string cacheKey = null!;
        var cacheValue = "Dummy";

        Action action = () => memoryCache.GetValue(cacheKey);
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);

        action = () => memoryCache.SetValue(cacheKey, cacheValue);
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }

    [Fact]
    public void Should_throw_when_cache_value_is_null()
    {
        const string expected = "cacheValue";
        var memoryCache = new MemoryCacheProvider<string>();
        var cacheKey = "Dummy";
        string cacheValue = null!;

        var action = () => memoryCache.SetValue(cacheKey, cacheValue);
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
