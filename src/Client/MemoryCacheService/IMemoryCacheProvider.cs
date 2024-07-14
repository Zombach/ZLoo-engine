namespace MemoryCacheService
{
    public interface IMemoryCacheProvider<out TValue>
        where TValue : class
    {
        TValue? GetValue<TKey>(TKey key);

        void CleanCache();
    }
}
