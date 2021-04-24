using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Services;
using System.Collections.Generic;

namespace PremiumCalculator.Api.Controllers
{
    /// <summary>
    /// Provide support for getting supported Occupations and their corresponding ratings for premium calculation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]    
    public class OccupationController : ControllerBase
    {
        private IOccupationService _occupationService;

        /// <summary>
        /// Constructor for setting dependencies
        /// </summary>
        /// <param name="occupationService"></param>
        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        /// <summary>
        /// Get all occupations with rating factors for premium calculation
        /// </summary>
        /// <returns>Occupations with rating factors</returns>
        [HttpGet]        
        public ActionResult<List<Occupation>> GetOccupations()
        {
            List<Occupation> occupations = _occupationService.GetAllOccupations();           
            return Ok(occupations);
        }

        /// <summary>
        /// Get occupation with rating factors by ID for premium calculation
        /// </summary>
        /// <param name="id">Occupation ID</param>
        /// <returns>Occupation with rating factors</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Occupation> GetOccupation(int id)
        {
            Occupation occupation = _occupationService.GetOccupationByID(id);
            return Ok(occupation);
        }
    }
}
