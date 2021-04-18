using Moq;
using NUnit.Framework;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System;
using PremiumCalculator.Core.Common;

namespace PremiumCalculator.Test
{
    public class UnitTestCollection
    {        
        [Test]        
        public void CalculateValidation_Throw_When_ParameterIsNull()
        {
            var _occupationService = new Mock<IOccupationService>();            
            var _calculatorService = new CalculatorService(_occupationService.Object);

            var ex = Assert.Throws<Exception>(() => _calculatorService.CalculateMonthlyPremium(null));
            Assert.AreSame(Constants.CALCULATOR_PARAMETER_NULL_ERROR, ex.Message);            
        }

        [Test]
        public void CalculateValidation_Validate_Result()
        {                        
            var _occupationService = new Mock<IOccupationService>();
            var _calculatorService = new CalculatorService(_occupationService.Object);

            _occupationService.Setup(x => x.GetOccupationByID(1)).Returns(
                new Occupation { ID = 1, Name = "Cleaner", RatingDetail = new RatingDetail { ID = 3, Name = "Light Manual", Factor = (decimal)1.50 } });

            var actualResults =_calculatorService.CalculateMonthlyPremium(new CalculatorParameter { DeathSumInsured = 10000, OccupationID = 1, Age = 38 });

            Assert.AreEqual(6840m, actualResults);
        }
    }
}
