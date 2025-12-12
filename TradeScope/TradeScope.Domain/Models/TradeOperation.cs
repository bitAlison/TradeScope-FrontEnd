namespace TradeScope.Domain.Models
{
    public class TradeOperation
    {
        public DateTime Date { get; set; }
        public string Asset { get; set; } = string.Empty;
        public int Phase { get; set; }
        public int Contracts { get; set; }
        public TradeResult Result { get; set; }
        public int Points { get; set; }
        public string Pattern10x { get; set; } = string.Empty;
    }
}
