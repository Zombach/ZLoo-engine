using System.Collections.Generic;

namespace Localizer
{
    public class LocalizationOptions
    {
        public const string SectionKey = nameof(LocalizationOptions);

        public ICollection<string>? Directories { get; set; }
    }
}
