using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JsonConverterService.Interfaces
{
    public interface IJsonConverterProviderAsync<TModel>
    {
        Task<Memory<byte>> ToJson(TModel model, CancellationToken cancellationToken = default);
        Task<TModel> ToModel(Stream stream, CancellationToken cancellationToken = default);
    }
}
