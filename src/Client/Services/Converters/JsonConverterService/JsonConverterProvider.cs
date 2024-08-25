using System;
using System.Text.Json;
using JsonConverterService.Bases;
using JsonConverterService.Interfaces;

namespace JsonConverterService
{
    public abstract class JsonConverterProvider<TModel> : BaseJsonConverterProvider, IJsonConverterProvider<TModel>
        where TModel : class
    {
        public virtual string ToJson(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var json = JsonSerializer.Serialize(model, Options);
            return json ?? throw new NotSupportedException(nameof(json));
        }

        public virtual TModel ToModel(string json)
        {
            if (json is null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            var model = JsonSerializer.Deserialize<TModel>(json, Options);
            return model ?? throw new JsonException(nameof(model));
        }
    }
}
