using Moq;
using NUnit.Framework;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System;
using PremiumCalculator.Core.Common;

namespace PremiumCalculator.Test
{
    public class CalculateServiceUnitTestCollection
    {
        Mock<IOccupationService> _occupationService;
        CalculatorService _calculatorService;

        [SetUp]
        public void CalculateService_Setup()
        {
            _occupationService = new Mock<IOccupationService>();
            _calculatorService = new CalculatorService(_occupationService.Object);
        }

        [Test]        
        public void CalculateMonthlyPremium_Throw_When_ParameterIsNull()
        {
            var ex = Assert.Throws<Exception>(() => _calculatorService.CalculateMonthlyPremium(null));
            
            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_NULL_ERROR == ex.Message, "CalculateMonthlyPremium_Throw_When_ParameterIsNull success");
        }

        [Test]
        public void CalculateMonthlyPremium_Throw_When_DeathSumInsured_Is_0()
        {            
            CalculatorParameter calculatorParameter = new CalculatorParameter { DeathSumInsured = 0 };

            var ex = Assert.Throws<Exception>(() => _calculatorService.CalculateMonthlyPremium(calculatorParameter));

            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_DEATH_SUM_INSURED_NULL_ERROR == ex.Message, "CalculateMonthlyPremium_Throw_When_DeathSumInsured_Is_0 success");
        }

        [Test]
        public void CalculateMonthlyPremium_Throw_When_Age_Is_0()
        {            
            CalculatorParameter calculatorParameter = new CalculatorParameter { Age = 0, DeathSumInsured = 10000 };

            var ex = Assert.Throws<Exception>(() => _calculatorService.CalculateMonthlyPremium(calculatorParameter));

            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_AGE_NULL_ERROR == ex.Message, "CalculateMonthlyPremium_Throw_When_Age_Is_0 success");
        }

        [Test]
        public void CalculateMonthlyPremium_Throw_When_Age_Is_Greater_Than_150()
        {           
            CalculatorParameter calculatorParameter = new CalculatorParameter { Age = 151, DeathSumInsured = 10000 };

            var ex = Assert.Throws<Exception>(() => _calculatorService.CalculateMonthlyPremium(calculatorParameter));

            Assert.IsTrue(Constants.CALCULATOR_PARAMETER_AGE_RANGE_ERROR == ex.Message, "CalculateMonthlyPremium_Throw_When_Age_Is_Greater_Than_150 success");
        }        

        [Test]
        public void CalculateMonthlyPremium_Validate_Result()
        {            
            _occupationService.Setup(x => x.GetOccupationByID(1)).Returns(
                new Occupation
                {
                    ID = 1,
                    Name = It.IsAny<string>(),
                    RatingDetail = new RatingDetail
                    {
                        ID = It.IsAny<int>(),
                        Name = It.IsAny<string>(),
                        Factor = 1.5m
                    }
                });

            var actualResults = _calculatorService.CalculateMonthlyPremium(new CalculatorParameter { DeathSumInsured = 10000, OccupationID = 1, Age = 38 });

            Assert.IsTrue(570m == actualResults, "CalculateMonthlyPremium_Validate_Result success.");
        }
    }
}
