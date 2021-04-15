using PremiumCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalculator.Service.Common;

namespace PremiumCalculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(CalculatorParameter calculatorParameter)
        {
            decimal premium = 0;

            if (calculatorParameter == null)
            {
                throw new Exception(Constants.CALCULATOR_PARAMETER_NULL_ERROR);
            }

            premium = Math.Round(calculatorParameter.DeathSumInsured * 1 * calculatorParameter.Age / 1000 * 12, 4);

            return premium;
        }
    }
}
