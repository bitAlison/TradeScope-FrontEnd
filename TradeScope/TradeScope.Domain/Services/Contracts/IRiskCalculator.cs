using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IRiskCalculator
    {
        RiskViewModel Calculate(RiskParameters parameters);
    }
}
