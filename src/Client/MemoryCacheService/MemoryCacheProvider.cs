using System;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheService
{
    public sealed class MemoryCacheProvider<TValue> : IMemoryCacheProvider<TValue>, IDisposable
        where TValue : class
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TValue? GetOrCreate(object key, Func<TValue> createItem)
        {
            if (_cache.TryGetValue(key, out TValue? cacheEntry)) // Ищем ключ в кэше.
            {
                return cacheEntry;
            }

            // Ключ отсутствует в кэше, поэтому получаем данные.
            cacheEntry = createItem();

            // Сохраняем данные в кэше. 
            _ = _cache.Set(key, cacheEntry);
            return cacheEntry;
        }

        public TValue? GetValue<TKey>(TKey key)
        {
            return key is null ? throw new ArgumentNullException(nameof(key)) :
                _cache.TryGetValue(key, out TValue? value)
                    ? value
                    : null;
        }

        public void CleanCache()
        {
            throw new NotImplementedException();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources.
                _cache.Dispose();
            }
            // Free native resources.
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
