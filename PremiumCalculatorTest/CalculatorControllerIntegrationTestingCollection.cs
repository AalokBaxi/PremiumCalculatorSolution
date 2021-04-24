using Moq;
using NUnit.Framework;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System;
using PremiumCalculator.Core.Common;
using PremiumCalculator.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Service.Extensions;

namespace PremiumCalculator.Test
{
    public class CalculatorControllerIntegrationTestingCollection
    {
        private IRatingDetailService _ratingDetailService;
        private IOccupationService _occupationService;
        private ICalculatorService _calculatorService;
        private CalculatorController _calculatorController; 

        [SetUp]
        public void CalculatorController_Setup()
        {
            _ratingDetailService = new RatingDetailService();
            _occupationService = new OccupationService(_ratingDetailService);
            _calculatorService = new CalculatorService(_occupationService);
            _calculatorController = new CalculatorController(_calculatorService);
        }

        [Test]
        public void CalculatorController_Throw_BadRequest_ParameterIsNull()
        {
            var badRequestResult = Assert.Throws<BusinessException>(() => _calculatorController.Calculate(null));
            Assert.IsInstanceOf<BusinessException>(badRequestResult);

            var actualErrorMessage = badRequestResult.Message;
            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_NULL_ERROR == actualErrorMessage, "CalculatorController_Throw_BadRequest_ParameterIsNull success");
        }

        [Test]
        public void CalculatorController_Validate_Result()
        {            
            var actualResults = _calculatorController.Calculate(new CalculatorParameter { DeathSumInsured = 10000, OccupationID = 1, Age = 38 });

            Assert.IsInstanceOf<OkObjectResult>(actualResults.Result);

            var actualPremium = (decimal)((ObjectResult)actualResults.Result).Value;
            Assert.IsTrue(570m == actualPremium, "CalculateMonthlyPremium_Validate_Result success.");
        }
    }
}
