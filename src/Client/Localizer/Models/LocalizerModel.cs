using System;
using System.Collections.Generic;
using Localizer.Models.Enums;

namespace Localizer.Models
{
    public class LocalizerModel
    {
        public Languages Language { get; set; }

        public IDictionary<Guid, string> Dictionary { get; } = new Dictionary<Guid, string>();
    }
}
