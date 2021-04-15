using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalculator.Service;
using PremiumCalculator.Data.Models;
using PremiumCalculatorCore.Models;

namespace PremiumCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ICalculatorService _calculatorService;
        private IOccupationService _occupationService;

        public CalculatorController(ICalculatorService calculatorService, IOccupationService occupationService)
        {
            _calculatorService = calculatorService;
            _occupationService = occupationService;
        }

        [HttpPost]
        public ActionResult<decimal> Calculate(CalculatorParameter calculatorParameter)
        {
            if (calculatorParameter == null)
            {
                return BadRequest();
            }

            return _calculatorService.Calculate(calculatorParameter);
        }

        [HttpGet]
        public ActionResult<List<Occupation>> GetOccupations()
        {
            return _occupationService.GetAllOccupations();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Occupation> GetOccupation(int id)
        {
            return _occupationService.GetOccupationByID(id);
        }
    }
}
