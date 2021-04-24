using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Extensions;
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

            #region Business validations
            if (calculatorParameter == null)
            {
                throw new BusinessException(Constants.CALCULATOR_PARAMETER_NULL_ERROR);
            }

            if (calculatorParameter.DeathSumInsured <= 0)
            {
                throw new BusinessException(Constants.CALCULATOR_PARAMETER_DEATH_SUM_INSURED_NULL_ERROR);
            }

            if (calculatorParameter.Age <= 0)
            {
                throw new BusinessException(Constants.CALCULATOR_PARAMETER_AGE_NULL_ERROR);
            }

            if (calculatorParameter.Age > 150)
            {
                throw new BusinessException(Constants.CALCULATOR_PARAMETER_AGE_RANGE_ERROR);
            }
            #endregion

            // Get occupation details
            Occupation occupation = _occupationService.GetOccupationByID(calculatorParameter.OccupationID);

            premium = Math.Round(calculatorParameter.DeathSumInsured * occupation.RatingDetail.Factor * calculatorParameter.Age / 1000, 2);

            // If unable to calculate premium for given parameters
            if (!premium.HasValue)
            {
                throw new Exception(Constants.PREMIUM_NULL);
            }

            return premium;
        }
    }
}
