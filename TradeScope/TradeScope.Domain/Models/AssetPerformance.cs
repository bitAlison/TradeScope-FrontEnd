namespace TradeScope.Domain.Models
{
    public class AssetPerformance
    {
        public string Name { get; set; } = string.Empty;
        public string Meta { get; set; } = string.Empty;
        public int TotalPoints { get; set; }
        public double WinRate { get; set; } // em %
    }
}
