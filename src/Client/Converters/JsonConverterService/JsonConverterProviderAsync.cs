using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonConverterService
{
    public abstract class JsonConverterProviderAsync<TModel> : BaseJsonConverterProvider, IJsonConverterProviderAsync<TModel>
        where TModel : class
    {
        public virtual async Task<Memory<byte>> ToJson(TModel model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var memoryStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memoryStream, model, Options, cancellationToken);

            return memoryStream.ToArray();
        }

        public virtual async Task<TModel> ToModel(Stream stream, CancellationToken cancellationToken)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var model = await JsonSerializer.DeserializeAsync<TModel>(stream, Options, cancellationToken);
            return model ?? throw new JsonException(nameof(model));
        }
    }
}
