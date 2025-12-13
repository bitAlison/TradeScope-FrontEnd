using System.Text.Json;

using Microsoft.Extensions.Hosting;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class JsonTradeStore : ITradeStore
    {
        private readonly string _filePath;
        private static readonly SemaphoreSlim _mutex = new(1, 1);

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public JsonTradeStore(IHostEnvironment env)
        {
            var dir = Path.Combine(env.ContentRootPath, "App_Data");
            Directory.CreateDirectory(dir);
            _filePath = Path.Combine(dir, "tradescope.state.json");
        }

        public async Task<TradeScopeState> LoadAsync(CancellationToken ct = default)
        {
            await _mutex.WaitAsync(ct);
            try
            {
                if (!File.Exists(_filePath))
                {
                    var initial = new TradeScopeState();
                    await SaveInternalAsync(initial, ct);
                    return initial;
                }

                var json = await File.ReadAllTextAsync(_filePath, ct);
                var state = JsonSerializer.Deserialize<TradeScopeState>(json, JsonOptions);

                return state ?? new TradeScopeState();
            }
            finally
            {
                _mutex.Release();
            }
        }

        public async Task SaveAsync(TradeScopeState state, CancellationToken ct = default)
        {
            await _mutex.WaitAsync(ct);
            try
            {
                await SaveInternalAsync(state, ct);
            }
            finally
            {
                _mutex.Release();
            }
        }

        private async Task SaveInternalAsync(TradeScopeState state, CancellationToken ct)
        {
            var tmp = _filePath + ".tmp";
            var json = JsonSerializer.Serialize(state, JsonOptions);

            await File.WriteAllTextAsync(tmp, json, ct);
            File.Copy(tmp, _filePath, overwrite: true);
            File.Delete(tmp);
        }
    }
}
