using Moq;
using NUnit.Framework;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System;
using PremiumCalculator.Core.Common;
using PremiumCalculator.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PremiumCalculator.Test
{
    public class CalculatorControllerUnitTestCollection
    {
        private Mock<ICalculatorService> _calculatorService;
        private CalculatorController _calculatorController; 

        [SetUp]
        public void CalculatorController_Setup()
        {
            _calculatorService = new Mock<ICalculatorService>();
            _calculatorController = new CalculatorController(_calculatorService.Object);
        }

        [Test]
        public void CalculatorController_Throw_BadRequest_ParameterIsNull()
        {
            var badRequestResult = _calculatorController.Calculate(null);
            Assert.IsInstanceOf<BadRequestObjectResult>(badRequestResult.Result);

            var actualErrorMessage = ((ObjectResult)badRequestResult.Result).Value.ToString();
            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_NULL_ERROR == actualErrorMessage, "CalculatorController_Throw_BadRequest_ParameterIsNull success");
        }
    }
}
