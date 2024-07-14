using System;

namespace LocalizationService
{
    public interface ILocalizationService
    {
        void GetValue(Guid key);
    }
}
