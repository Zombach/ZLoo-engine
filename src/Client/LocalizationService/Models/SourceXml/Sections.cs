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
    public class Sections
    {
        private const string CountAttribute = "count";
        private const string SectionElement = nameof(Section);

        private string? _count;
        private Collection<Section>? _sectionCollection;

        [XmlAttribute(AttributeName = CountAttribute)]
        public string? Count
        {
            get => _count;
            set => _count = value;
        }

        [XmlElement(ElementName = SectionElement)]
        public Collection<Section>? SectionCollection
        {
            get => _sectionCollection;
            set => _sectionCollection = value;
        }
    }
}
