using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IOperationsService
    {
        IEnumerable<TradeOperation> GetOperations(string userId, DateTime? from = null, DateTime? to = null);
    }
}
