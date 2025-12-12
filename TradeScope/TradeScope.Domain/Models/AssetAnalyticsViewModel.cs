namespace TradeScope.Domain.Models
{
    public class AssetAnalyticsViewModel
    {
        public List<AssetPerformance> Assets { get; set; } = [];
        public string BestAssetName { get; set; } = string.Empty;
        public string WorstAssetName { get; set; } = string.Empty;
    }
}
