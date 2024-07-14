using System.Collections.Generic;

#pragma warning disable CA2227

namespace LocalizationService
{
    public class LocalizationOptions
    {
        public const string SectionKey = nameof(LocalizationOptions);

        public ICollection<string>? Directories { get; set; }
    }
}
