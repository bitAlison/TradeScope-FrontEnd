using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Infrastructure.Repositories
{
    public class InMemoryTradeRepository : ITradeRepository
    {
        private readonly Dictionary<string, List<TradeOperation>> _storage = [];

        public InMemoryTradeRepository()
        {
            // Seed inicial que hoje está no seu OperationsController
            var defaultUser = "default";
            _storage[defaultUser] = [];
        }

        public IEnumerable<TradeOperation> GetAll(string userId)
        {
            if (!_storage.TryGetValue(userId, out var list))
                return [];

            return list;
        }

        public void Add(string userId, TradeOperation operation)
        {
            if (!_storage.TryGetValue(userId, out var list))
            {
                list = [];
                _storage[userId] = list;
            }
            list.Add(operation);
        }
    }
}
