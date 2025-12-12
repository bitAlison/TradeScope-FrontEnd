using System.Text.Json;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class JsonTradeStore : ITradeStore
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _mutex = new(1, 1);
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonTradeStore(IWebHostEnvironment env)
        {
            // Use App_Data (created automatically if missing)
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
                    var seed = new TradeScopeState();
                    await SaveInternalAsync(seed, ct);
                    return seed;
                }

                var json = await File.ReadAllTextAsync(_filePath, ct);
                var state = JsonSerializer.Deserialize<TradeScopeState>(json, _jsonOptions) ?? new TradeScopeState();

                // Defensive defaults
                state.Settings ??= new TradeScopeState().Settings;
                state.Operations ??= new List<TradeOperation>();

                return state;
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

        public async Task<IReadOnlyList<TradeOperation>> GetOperationsAsync(CancellationToken ct = default)
        {
            var s = await LoadAsync(ct);
            return s.Operations
                .OrderByDescending(o => o.Date)
                .ThenByDescending(o => o.Asset)
                .ToList();
        }

        public async Task AddOperationAsync(TradeOperation op, CancellationToken ct = default)
        {
            var s = await LoadAsync(ct);

            // Normalize: keep Points always positive; sign comes from Result
            op.Points = Math.Abs(op.Points);

            s.Operations.Add(op);
            await SaveAsync(s, ct);
        }

        public async Task DeleteOperationAsync(DateTime date, string asset, int points, int contracts, CancellationToken ct = default)
        {
            var s = await LoadAsync(ct);

            var normalizedPoints = Math.Abs(points);

            var item = s.Operations.FirstOrDefault(o =>
                o.Date.Date == date.Date &&
                string.Equals(o.Asset, asset, StringComparison.OrdinalIgnoreCase) &&
                o.Points == normalizedPoints &&
                o.Contracts == contracts);

            if (item != null)
            {
                s.Operations.Remove(item);
                await SaveAsync(s, ct);
            }
        }

        public async Task<SettingsViewModel> GetSettingsAsync(CancellationToken ct = default)
        {
            var s = await LoadAsync(ct);
            return s.Settings;
        }

        public async Task SaveSettingsAsync(SettingsViewModel settings, CancellationToken ct = default)
        {
            var s = await LoadAsync(ct);
            s.Settings = settings;
            await SaveAsync(s, ct);
        }

        private async Task SaveInternalAsync(TradeScopeState state, CancellationToken ct)
        {
            var json = JsonSerializer.Serialize(state, _jsonOptions);
            await File.WriteAllTextAsync(_filePath, json, ct);
        }
    }
}
