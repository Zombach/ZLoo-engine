using System;
using Microsoft.Extensions.Options;

namespace Localizer
{
    public class LocalizationService : ILocalizationService
    {
        private IOptions<LocalizationOptions> _localizationOptions;

        public LocalizationService(IOptions<LocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }

        public void GetValue(Guid key)
        {
            throw new NotImplementedException();
        }

        private void Loader()
        {

        }
    }
}
