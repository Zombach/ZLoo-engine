using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace MemoryCacheService;

public sealed class MemoryCacheProvider<TCacheValue> : IMemoryCacheProvider<TCacheValue>, IDisposable
    where TCacheValue : class
{
    private readonly ILogger _logger = Log.ForContext<MemoryCacheProvider<TCacheValue>>();
    private int _recordersCount;
    private readonly ManualResetEventSlim _manualResetEventSlim = new(true);
    private readonly MemoryCache _cache = new(new MemoryCacheOptions());

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

        _manualResetEventSlim.Wait();
        try
        {
            _ = Interlocked.Increment(ref _recordersCount);

            _ = _cache.Set(cacheKey, cacheValue);
            _logger.Debug("For key: {@cacheKey}, set value: {@cacheValue}", cacheKey, cacheValue);
        }
        finally
        {
            _ = Interlocked.Decrement(ref _recordersCount);
        }
    }

    public TCacheValue? GetValue<TCacheKey>(TCacheKey cacheKey)
    {
        if (cacheKey is null)
        {
            throw new ArgumentNullException(nameof(cacheKey));
        }

        _manualResetEventSlim.Wait();
        try
        {
            _ = Interlocked.Increment(ref _recordersCount);

            if (_cache.TryGetValue(cacheKey, out TCacheValue? cacheValue))
            {
                _logger.Debug("For key: {@cacheKey}, get value: {@cacheValue}", cacheKey, cacheValue);
            }
            else
            {
                _logger.Debug("For key: {@cacheKey}, value not found", cacheKey);
            }
            return cacheValue;
        }
        finally
        {
            if (_recordersCount > 0)
            {
                _ = Interlocked.Decrement(ref _recordersCount);
            }
        }
    }

    public async Task CleanCache(CancellationToken cancellationToken)
    {
        _manualResetEventSlim.Reset();

        while (_recordersCount != 0)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken);
        }

        _cache.Clear();
        _logger.Debug("Memory Cache cleared");

        _manualResetEventSlim.Set();
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cache.Dispose();
            _manualResetEventSlim.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
