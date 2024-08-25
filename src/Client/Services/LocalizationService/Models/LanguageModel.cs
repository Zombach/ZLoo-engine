using System;
using System.Collections.Generic;
using System.Linq;
using LocalizationService.Models.Enums;
using LocalizationService.Models.SourceXml;
using Serilog;

namespace LocalizationService.Models
{
    public class LanguageModel
    {
        private readonly ILogger _logger = Log.ForContext<LanguageModel>();

        private readonly Dictionary<string, LanguageSectionModel> _sections;

        public Languages Language { get; }

        public LanguageModel(Source source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Language = Enum.Parse<Languages>(source.Language);

            _sections = new Dictionary<string, LanguageSectionModel>();

            foreach (var section in source.Sections.SectionCollection)
            {
                var dictionary = section.ItemCollection.ToDictionary(item => item.Key, item => item.Value);

                var languageSection = new LanguageSectionModel(dictionary);
                _sections.Add(section.Name, languageSection);
            }
        }

        public string? this[string name, string key]
        {
            get
            {
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (_sections.TryGetValue(name, out var section))
                {
                    _logger.Debug("By name {@name}, section received: {@section}", name, section);
                }
                else
                {
                    _logger.Debug("By name {@name}, section not found", name);
                }

                return section?[key];
            }
        }
    }
}
