using System.Collections.ObjectModel;
using FluentAssertions;
using LocalizationService.Models;
using LocalizationService.Models.SourceXml;

namespace LocalizationService.Tests.Models;

public class LanguageModelTests
{
    private readonly Source _source = new()
    {
        Language = "Russian",
        Sections = new Sections
        {
            Count = "1",
            SectionCollection = new Collection<Section>(
            [
                new()
                {
                    Name = "Test",
                    ItemCollection = new Collection<Item>(
                    [
                        new()
                        {
                            Key = "1",
                            Value = "Text"
                        }
                    ])
                }
            ])
        }
    };

    [Fact]
    public void Should_throw_when_section_key_is_null()
    {
        var language = new LanguageModel(_source);
        const string expected = "name";
        const string key = "Dummy";
        string name = null!;

        var func = () => language[name, key];
        func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }

    [Fact]
    public void Should_throw_when_key_is_null()
    {
        var language = new LanguageModel(_source);
        const string expected = "key";
        const string name = "Dummy";
        string key = null!;

        var func = () => language[name, key];
        func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(expected);
    }
}
