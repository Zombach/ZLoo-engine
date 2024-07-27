using System;

namespace JsonConverterService
{
    public abstract class JsonConverterProvider<TModel> : IJsonConverterProvider<TModel>
        where TModel : class
    {
        public virtual string ToJson(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            throw new NotImplementedException();
        }

        public virtual TModel ToModel(string json)
        {
            if (json is null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            throw new NotImplementedException();
        }
    }
}
