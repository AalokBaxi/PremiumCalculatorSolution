using PremiumCalculator.Core.Models;

namespace PremiumCalculator.Service.Services
{
    public interface ICalculatorService
    {
        decimal? CalculateMonthlyPremium(CalculatorParameter calculatorParameter);
    }
}
