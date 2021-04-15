using PremiumCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Service
{
    public interface ICalculatorService
    {
        decimal Calculate(CalculatorParameter calculatorParameter);
    }
}
