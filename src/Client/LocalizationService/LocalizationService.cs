using System;
using System.Collections.Generic;
using System.Linq;
using LocalizationService.Models;
using LocalizationService.Models.Enums;
using LocalizationService.Options;
using Microsoft.Extensions.Options;
using Serilog;

namespace LocalizationService
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ILogger _logger = Log.ForContext<LocalizationService>();

        private readonly IDictionary<Languages, LanguageModel> _languages;

        public static Languages Languages { get; private set; } = Languages.Russian;

        public LocalizationService(IOptions<LocalizationOptions> localizationOptions)
        {
            _languages = new Dictionary<Languages, LanguageModel>();

            var pairs = localizationOptions.Value.Languages.ToList();

            foreach (var (language, path) in pairs)
            {
            }
        }

        public static void SetLanguage(Languages languages)
        {
            Languages = languages;
        }

        public void GetValue(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
