namespace MemoryCacheService
{
    public interface IMemoryCacheProvider<TCacheValue>
        where TCacheValue : class
    {
        void SetValue<TCacheKey>(TCacheKey cacheKey, TCacheValue cacheValue);

        TCacheValue? GetValue<TCacheKey>(TCacheKey cacheKey);

        void CleanCache();
    }
}
