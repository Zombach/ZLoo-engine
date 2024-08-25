using System.ComponentModel.DataAnnotations;

namespace LocalizationService.Options
{
    public class LocalizationOptions
    {
        public const string SectionKey = nameof(LocalizationOptions);

        [Required] public string Directory { get; set; } = null!;
    }
}
