using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ITradeRepository
    {
        IEnumerable<TradeOperation> GetAll(string userId);
        void Add(string userId, TradeOperation operation);
    }
}
