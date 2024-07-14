using System;
using LocalizationService.Models.Enums;
using Microsoft.Extensions.Options;
using Serilog;

namespace LocalizationService
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ILogger _logger = Log.ForContext<LocalizationService>();

        private readonly IOptions<LocalizationOptions> _localizationOptions;

        //private readonly IDictionary<Languages, >

        public static Languages Languages { get; private set; } = Languages.Russian;

        public LocalizationService(IOptions<LocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
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
