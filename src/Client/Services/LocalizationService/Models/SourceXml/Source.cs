using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace LocalizationService.Models.SourceXml;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = nameof(Source), Namespace = "", IsNullable = false)]
public class Source
{
    private const string LanguageAttribute = "language";

    private string _language = null!;
    private Sections _sections = null!;

    [XmlAttribute(AttributeName = LanguageAttribute)]
    public string Language
    {
        get => _language;
        set => _language = value ?? throw new ArgumentNullException(nameof(value));
    }

    [XmlElement(ElementName = nameof(Sections))]
    public Sections Sections
    {
        get => _sections;
        set => _sections = value ?? throw new ArgumentNullException(nameof(value));
    }
}
