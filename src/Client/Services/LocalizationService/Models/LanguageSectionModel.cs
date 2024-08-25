using System;
using System.Collections.Generic;
using Serilog;

namespace LocalizationService.Models;

public class LanguageSectionModel(IDictionary<string, string> section)
{
    private readonly ILogger _logger = Log.ForContext<LanguageSectionModel>();

    public string? this[string key]
    {
        get
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (section.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
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
