using LocalizationService.Models.Enums;

namespace LocalizationService;

public interface ILocalizationProvider
{
    void SetLanguage(Languages languages);
    string? GetValue(string name, string key);
}
