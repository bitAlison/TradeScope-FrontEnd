using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradeScope.Domain.Models
{
    /// <summary>
    /// Withdrawl Settings
    /// </summary>
    public sealed class WithdrawlSettings
    {
        /// <summary>
        /// Estimate Withdrawal Per Week
        /// </summary>
        public decimal EstimateWithdrawalPerWeek { get; set; } = default!;

        /// <summary>
        /// Estimate Increment Withdrawal Per Week
        /// </summary>
        public decimal EstimateIncrementWithdrawalPerWeek { get; set; } = default!;

        /// <summary>
        /// Max Withdrawal Per Week
        /// </summary>
        public decimal MaxWithdrawalPerWeek { get; set; } = default!;

        /// <summary>
        /// Estimate Withdrawal Per Month
        /// </summary>
        public decimal EstimateWithdrawalPerMonth { get; set; } = default!;

        /// <summary>
        /// Estimate Increment Withdrawal Per Month
        /// </summary>
        public decimal EstimateIncrementWithdrawalPerMonth { get; set; } = default!;

        /// <summary>
        /// Max Withdrawal Per Month
        /// </summary>
        public decimal MaxWithdrawalPerMonth { get; set; } = default!;

        /// <summary>
        /// Max Withdrawal Total
        /// </summary>
        public decimal MaxWithdrawalTotal { get; set; } = default!;

        /// <summary>
        /// Withdrawl Frequency
        /// </summary>
        public WithdrawlFrequency WithdrawlFrequency { get; set; } = default!;

        /// <summary>
        /// Withdrawl Frequency List Options
        /// </summary>
        public List<SelectListItem> WithdrawlFrequencyOptions { get; set; } = [];
    }
}
