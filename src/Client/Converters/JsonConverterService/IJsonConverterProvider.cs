namespace JsonConverterService
{
    public interface IJsonConverterProvider<TModel>
    {
        string ToJson(TModel model);
        TModel ToModel(string json);
    }
}
