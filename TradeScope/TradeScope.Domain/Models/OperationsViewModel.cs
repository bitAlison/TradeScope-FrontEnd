namespace TradeScope.Domain.Models
{
    public class OperationsViewModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? AssetFilter { get; set; }
        public int? PhaseFilter { get; set; }
        public TradeResult? ResultFilter { get; set; }

        public List<TradeOperation> Operations { get; set; } = [];
    }
}
