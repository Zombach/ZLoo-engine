using FluentAssertions;
using LocalizationService.Models;

namespace LocalizationService.Tests.Models;

public class LanguageModelTests
{
    [Fact]
    public void Should_throw_when_section_key_is_null()
    {
        var sections = new Dictionary<string, LanguageSectionModel>();
        var language = new LanguageModel(sections);
        const string expected = "sectionKey";
        const string key = "Dummy";
        string sectionKey = null!;

        var func = () => language[sectionKey, key];
        func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }

    [Fact]
    public void Should_throw_when_key_is_null()
    {
        var sections = new Dictionary<string, LanguageSectionModel>();
        var language = new LanguageModel(sections);
        const string expected = "key";
        const string sectionKey = "Dummy";
        string key = null!;

        var func = () => language[sectionKey, key];
        func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
