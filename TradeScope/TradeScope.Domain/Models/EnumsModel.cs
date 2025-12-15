using System.ComponentModel;

namespace TradeScope.Domain.Models
{
    public enum TradeResult
    {
        Win,
        Loss
    }

    public enum WithdrawlFrequency
    {
        [Description("Start After First Week")]
        StartAfterFirstWeek,

        [Description("Start After Second Week")]
        StartAfterSecondWeek,

        [Description("Start After Third Week")]
        StartAfterThirdWeek,

        [Description("Start After First Month")]
        StartAfterFirstMonth,

        [Description("Start After Second Month")]
        StartAfterSecondMonth,

        [Description("Start After Third Month")]
        StartAfterThirdMonth,

        [Description("Daily")]
        Daily,

        [Description("Weekly")]
        Weekly,

        [Description("Monthly")]
        Monthly
    }
}
