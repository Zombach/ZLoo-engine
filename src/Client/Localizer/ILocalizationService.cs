using System;

namespace Localizer
{
    public interface ILocalizationService
    {
        void GetValue(Guid key);
    }
}
