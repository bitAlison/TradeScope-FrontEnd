namespace TradeScope.Domain.Models
{
    public class TradeScopeState
    {
        public decimal CurrentCapital { get; set; } = 20000m;
        public List<TradeOperation> Operations { get; set; } = [];
    }
}
