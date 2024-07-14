using System;
using System.Collections.Generic;
using Serilog;

namespace LocalizationService.Models
{
    public class LanguageModel
    {
        private readonly ILogger _logger = Log.ForContext<LanguageModel>();

        private readonly IDictionary<string, LanguageSectionModel> _sections;

        public LanguageModel(IDictionary<string, LanguageSectionModel> sections)
        {
            _sections = sections;
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
