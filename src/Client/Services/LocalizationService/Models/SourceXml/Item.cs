using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace LocalizationService.Models.SourceXml;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Item
{
    private const string KeyAttribute = "key";

    private string _key = null!;
    private string _value = null!;

    [XmlAttribute(AttributeName = KeyAttribute)]
    public string Key
    {
        get => _key;
        set => _key = value ?? throw new ArgumentNullException(nameof(value));
    }

    [XmlText]
    public string Value
    {
        get => _value;
        set => _value = value ?? throw new ArgumentNullException(nameof(value));
    }
}
