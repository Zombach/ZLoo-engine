using FluentAssertions;
using LocalizationService.Models;

namespace LocalizationService.Tests.Models;

public class LanguageSectionModelTests
{
    [Fact]
    public void Should_throw_when_key_is_null()
    {
        IDictionary<string, string> section = new Dictionary<string, string>();
        var languageSection = new LanguageSectionModel(section);
        const string expected = "key";
        string key = null!;

        var func = () => languageSection[key];
        func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
