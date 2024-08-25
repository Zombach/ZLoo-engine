using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LocalizationService.Models;
using LocalizationService.Models.Enums;
using LocalizationService.Models.SourceXml;
using LocalizationService.Options;
using Microsoft.Extensions.Options;
using Serilog;

namespace LocalizationService
{
    public class LocalizationProvider : ILocalizationProvider
    {
        private readonly ILogger _logger = Log.ForContext<LocalizationProvider>();

        private readonly Dictionary<Languages, LanguageModel> _languages;

        public Languages Languages { get; private set; } = Languages.Russian;

        public LocalizationProvider(IOptions<LocalizationOptions> localizationOptions)
        {
            if (localizationOptions is null)
            {
                throw new ArgumentNullException(nameof(localizationOptions));
            }

            var files = Directory.EnumerateFiles(localizationOptions.Value.Directory, "Language.*.xml", SearchOption.TopDirectoryOnly);

            _languages = new Dictionary<Languages, LanguageModel>();

            foreach (var path in files)
            {
                using var streamReader = new StreamReader(path);
                using var reader = XmlReader.Create(streamReader);
                var serializer = new XmlSerializer(typeof(Source));

                if (!(serializer.Deserialize(reader) is Source source))
                {
                    throw new InvalidOperationException(nameof(source));
                }

                var language = new LanguageModel(source);
                _languages.Add(language.Language, language);
            }
        }

        public void SetLanguage(Languages languages)
        {
            if (Languages is Languages.Unknown)
            {
                throw new ArgumentException(nameof(Languages.Unknown));
            }

            Languages = languages;
            _logger.Debug("Set language: {@language}", languages);
        }

        public string? GetValue(string name, string key)
        {
            return _languages[Languages][name, key];
        }
    }
}
