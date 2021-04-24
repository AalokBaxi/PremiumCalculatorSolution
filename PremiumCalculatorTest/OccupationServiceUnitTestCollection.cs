using Moq;
using NUnit.Framework;
using PremiumCalculator.Core.Common;
using PremiumCalculator.Service.Extensions;
using PremiumCalculator.Service.Services;
using System;

namespace PremiumCalculator.Test
{
    public class OccupationServiceUnitTestCollection
    {
        Mock<IRatingDetailService> _ratingDetailService;
        OccupationService _occupationService;

        [SetUp]
        public void OccupationService_Setup()
        {
            _ratingDetailService = new Mock<IRatingDetailService>();
            _occupationService = new OccupationService(_ratingDetailService.Object);
        }

        [Test]
        public void GetOccupationByID_Throw_When_ID_Is_0()
        {
            var ex = Assert.Throws<BusinessException>(() => _occupationService.GetOccupationByID(0));

            Assert.IsTrue(Constants.OCCUPATION_ID_NULL_ERROR == ex.Message, "GetOccupationByID_Throw_When_ID_Is_0 success");
        }

        [Test]
        public void GetOccupationByID_Throw_When_Occupations_IsNull()
        {
            Mock<IOccupationService> mock = new Mock<IOccupationService>();
            mock.Setup(s => s.GetAllOccupations()).Throws(new Exception(Constants.OCCUPATION_NULL_ERROR));

            var ex = Assert.Throws<Exception>(() => mock.Object.GetAllOccupations());

            Assert.IsTrue(Constants.OCCUPATION_NULL_ERROR == ex.Message, "GetOccupationByID_Throw_When_Occupations_IsNull success");
        }       
    }
}
