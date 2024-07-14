using System;
using System.Collections.Generic;
using Serilog;

namespace LocalizationService.Models
{
    public class SectionModel
    {
        private readonly ILogger _logger = Log.ForContext<SectionModel>();

        private readonly IDictionary<string, string> _section;

        public SectionModel(IDictionary<string, string> section)
        {
            _section = section;
        }

        public string? this[string key]
        {
            get
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (_section.TryGetValue(key, out var value))
                {
                    _logger.Debug("By key {@key}, value received: {@value}", key, value);
                }
                else
                {
                    _logger.Debug("By key {@key}, value not found", key);
                }

                return value;
            }
        }
    }
}
