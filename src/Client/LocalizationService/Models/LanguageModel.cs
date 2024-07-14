using System;
using System.Collections.Generic;
using Serilog;

namespace LocalizationService.Models
{
    public class LanguageModel
    {
        private readonly ILogger _logger = Log.ForContext<LanguageModel>();

        private readonly IDictionary<string, SectionModel> _sections;

        public LanguageModel(IDictionary<string, SectionModel> sections)
        {
            _sections = sections;
        }

        public string? this[string sectionKey, string key]
        {
            get
            {
                if (sectionKey is null)
                {
                    throw new ArgumentNullException(nameof(sectionKey));
                }

                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (_sections.TryGetValue(sectionKey, out var section))
                {
                    _logger.Debug("By sectionKey {@sectionKey}, section received: {@section}", sectionKey, section);
                }
                else
                {
                    _logger.Debug("By sectionKey {@sectionKey}, section not found", sectionKey);
                }

                return section?[key];
            }
        }
    }
}
