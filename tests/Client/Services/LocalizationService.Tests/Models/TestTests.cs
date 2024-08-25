using System.Xml.Serialization;
using FluentAssertions;
using LocalizationService.Models.SourceXml;

namespace LocalizationService.Tests.Models;

public class TestTests
{
    [Fact]
    public void Test_xml()
    {
        var xml =
            "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
            "<Source language=\"Russian\">\r\n" +
            "  <Sections count=\"3\">\r\n" +
            "    <Section name=\"A\">\r\n" +
            "      <Item key=\"1\">Text</Item>\r\n" +
            "      <Item key=\"2\">Text2</Item>\r\n" +
            "    </Section>\r\n" +
            "    <Section name=\"B\">\r\n" +
            "      <Item key=\"A\">Text</Item>\r\n" +
            "      <Item key=\"2\">Text2</Item>\r\n" +
            "    </Section>\r\n" +
            "    <Section name=\"C\">\r\n" +
            "      <Item key=\"4\">Text4</Item>\r\n" +
            "      <Item key=\"5\">Text5</Item>\r\n" +
            "    </Section>\r\n" +
            "  </Sections>\r\n" +
            "</Source>\r\n";

        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(xml);
        writer.Flush();
        stream.Position = 0;
        var reader = new XmlSerializer(typeof(Source));
        using var sr = new StreamReader(stream);
        var source = reader.Deserialize(sr) as Source;

        source.Should().NotBeNull();
        source.Language.Should().Be("Russian");
        source.Sections.Should().NotBeNull();
        source.Sections.Count.Should().Be("3");

        var sectionCollection = source.Sections.SectionCollection;
        sectionCollection.Should().NotBeNull();
        sectionCollection.Count.Should().Be(3);

        var section = sectionCollection[0];
        section.Name.Should().Be("A");
        section.ItemCollection.Should().NotBeNull();
        section.ItemCollection.Count.Should().Be(2);

        var item = section.ItemCollection[0];
        item.Key.Should().Be("1");
        item.Value.Should().Be("Text");

        item = section.ItemCollection[1];
        item.Key.Should().Be("2");
        item.Value.Should().Be("Text2");
    }
}
