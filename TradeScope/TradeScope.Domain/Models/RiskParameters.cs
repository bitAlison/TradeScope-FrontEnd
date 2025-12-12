namespace TradeScope.Domain.Models
{
    public class RiskParameters
    {
        public decimal Capital { get; set; }

        /// <summary>
        /// Percentual de risco por trade (ex: 0.5 = 0,5%)
        /// </summary>
        public double RiskPerTradePercent { get; set; }

        /// <summary>
        /// Quantidade de trades por dia
        /// </summary>
        public int TradesPerDay { get; set; }

        /// <summary>
        /// Expectativa de EV por trade em % (ex: 0.2 = 0,2% por trade)
        /// </summary>
        public double ExpectedEvPerTradePercent { get; set; }

        /// <summary>
        /// Rótulo da fase (ex.: "Fase 1 · Agressivo")
        /// </summary>
        public string PhaseLabel { get; set; } = string.Empty;
    }
}
