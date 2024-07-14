using System.Collections.Generic;
using LocalizationService.Models.Enums;

#pragma warning disable CA2227

namespace LocalizationService.Options
{
    public class LocalizationOptions
    {
        public const string SectionKey = nameof(LocalizationOptions);

        public IDictionary<Languages, string> Languages { get; set; }
    }
}
