using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System;

namespace PremiumCalculator.Api.Controllers
{
    /// <summary>
    /// Provide support for premium calculation
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ICalculatorService _calculatorService;

        /// <summary>
        /// Constructor for setting dependencies
        /// </summary>
        /// <param name="calculatorService"></param>
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
            
        }

        /// <summary>
        /// Calculate monthly premium
        /// </summary>
        /// <param name="calculatorParameter">Input object of type CalculatorParameter for premium calculation</param>
        /// <returns>Monthly premium</returns>
        [HttpPost]
        public ActionResult<decimal> Calculate(CalculatorParameter calculatorParameter)
        {
            decimal? monthlyPremium = null;

            if (calculatorParameter == null)
            {
                return BadRequest();
            }

            try
            {
                monthlyPremium = _calculatorService.CalculateMonthlyPremium(calculatorParameter);

                if (!monthlyPremium.HasValue)
                {
                    return BadRequest(Constants.PREMIUM_NULL);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(monthlyPremium);
        }        
    }
}
