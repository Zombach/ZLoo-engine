using FluentAssertions;

namespace MemoryCacheService.Tests;

public class MemoryCacheProviderTests
{
    [Fact]
    public void Should_throw_when_cache_key_is_null()
    {
        IMemoryCacheProvider<string> memoryCache = new MemoryCacheProvider<string>();
        const string expected = "key";
        string key = null!;

        Action action = () => memoryCache.GetValue(key);
        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
