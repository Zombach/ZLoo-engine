using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

#pragma warning disable CA2227

namespace LocalizationService.Models.SourceXml
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Section
    {
        private const string NameAttribute = "name";
        private const string ItemElement = "Item";

        private string? _name;
        private Collection<Item>? _itemCollection;

        [XmlAttribute(AttributeName = NameAttribute)]
        public string? Name
        {
            get => _name;
            set => _name = value;
        }

        [XmlElement(ElementName = ItemElement)]
        public Collection<Item>? ItemCollection
        {
            get => _itemCollection;
            set => _itemCollection = value;
        }
    }
}
