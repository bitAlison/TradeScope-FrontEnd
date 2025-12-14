namespace TradeScope.Domain.Models
{
    public enum TradeResult
    {
        Win,
        Loss
    }

    public enum WithdrawlFrequency
    {
        StartAfterFirtsWeek,
        StartAfterSecondWeek,
        StartAfterThirdWeek,
        StartAfterFirstMonth,
        StartAfterSecondMonth,
        StartAfterThirdMonth,
        Daily,
        Weekly,
        Monthly
    }
}
