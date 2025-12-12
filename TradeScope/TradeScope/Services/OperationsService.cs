using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class OperationsService : IOperationsService
    {
        public IEnumerable<TradeOperation> GetOperations(string userId, DateTime? from = null, DateTime? to = null)
        {
            return default!;
        }
    }

}
