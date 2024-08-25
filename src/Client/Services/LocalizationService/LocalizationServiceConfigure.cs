using System;
using LocalizationService.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalizationService;

public static class LocalizationServiceConfigure
{
    public static IServiceCollection LocalizationConfigure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        _ = services.AddOptionsWithValidateOnStart<LocalizationOptions>()
            .Bind(configuration.GetSection(LocalizationOptions.SectionKey));

        return services.AddSingleton<ILocalizationProvider, LocalizationProvider>();
    }
}
