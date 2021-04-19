using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using System;

namespace PremiumCalculator.Service.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IOccupationService _occupationService;
        public CalculatorService(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }
        public decimal? CalculateMonthlyPremium(CalculatorParameter calculatorParameter)
        {
            decimal? premium = null;

            if (calculatorParameter == null)
            {
                throw new Exception(Constants.CALCULATOR_PARAMETER_NULL_ERROR);
            }

            Occupation occupation = _occupationService.GetOccupationByID(calculatorParameter.OccupationID);

            if (occupation != null && occupation.RatingDetail != null)
            {
                premium = Math.Round(calculatorParameter.DeathSumInsured * occupation.RatingDetail.Factor * calculatorParameter.Age / 1000, 2);
            }
            else
            {
                // Log -> Constants.OCCUPATION_NOT_FOUND;
                // Log -> Constants.RATING_NULL_ERROR;
            }

            return premium;
        }
    }
}
