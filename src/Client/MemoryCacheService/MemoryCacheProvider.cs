using System;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheService
{
    public sealed class MemoryCacheProvider<TCacheValue> : IMemoryCacheProvider<TCacheValue>, IDisposable
        where TCacheValue : class
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        //public TCacheValue? GetOrCreate(object key, Func<TCacheValue> createItem)
        //{
        //    if (_cache.TryGetValue(key, out TCacheValue? cacheEntry)) // Ищем ключ в кэше.
        //    {
        //        return cacheEntry;
        //    }

        //    // Ключ отсутствует в кэше, поэтому получаем данные.
        //    cacheEntry = createItem();

        //    // Сохраняем данные в кэше. 
        //    _ = _cache.Set(key, cacheEntry);
        //    return cacheEntry;
        //}

        public void SetValue<TCacheKey>(TCacheKey cacheKey, TCacheValue cacheValue)
        {
            if (cacheKey is null)
            {
                throw new ArgumentNullException(nameof(cacheKey));
            }

            if (cacheValue is null)
            {
                throw new ArgumentNullException(nameof(cacheValue));
            }

            _ = _cache.Set(cacheKey, cacheValue);
        }

        public TCacheValue? GetValue<TCacheKey>(TCacheKey cacheKey)
        {
            return cacheKey is null ? throw new ArgumentNullException(nameof(cacheKey))
                : _cache.TryGetValue(cacheKey, out TCacheValue? cacheValue)
                    ? cacheValue
                    : null;
        }

        public void CleanCache()
        {
            _cache.Clear();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cache.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
