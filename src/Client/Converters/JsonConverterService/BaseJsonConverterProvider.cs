using System.Text.Encodings.Web;
using System.Text.Json;

namespace JsonConverterService
{
    public abstract class BaseJsonConverterProvider
    {
        protected virtual JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
    }
}
