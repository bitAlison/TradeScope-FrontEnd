using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly ITradeRepository _tradeRepository;

        public OperationsService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public IEnumerable<TradeOperation> GetOperations(string userId, DateTime? from = null, DateTime? to = null)
        {
            var all = _tradeRepository.GetAll(userId);

            if (from.HasValue)
                all = all.Where(o => o.Date >= from.Value);

            if (to.HasValue)
                all = all.Where(o => o.Date <= to.Value);

            return all.OrderByDescending(o => o.Date);
        }
    }

}
