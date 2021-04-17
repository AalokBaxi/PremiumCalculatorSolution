using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Service.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly List<Occupation> _occupations;
        private readonly IRatingDetailService _ratingDetailService;

        public OccupationService(IRatingDetailService ratingDetailService)
        {
            _ratingDetailService = ratingDetailService;

            // This can come from repository using EF
            _occupations = new List<Occupation>();
            _occupations.Add(new Occupation { ID = 1, Name = "Cleaner", RatingDetail = new RatingDetail { ID = 3 } });
            _occupations.Add(new Occupation { ID = 2, Name = "Doctor", RatingDetail = new RatingDetail { ID = 1 } });
            _occupations.Add(new Occupation { ID = 3, Name = "Author", RatingDetail = new RatingDetail { ID = 2 } });
            _occupations.Add(new Occupation { ID = 4, Name = "Farmer", RatingDetail = new RatingDetail { ID = 4 } });
            _occupations.Add(new Occupation { ID = 5, Name = "Mechanic", RatingDetail = new RatingDetail { ID = 4 } });
            _occupations.Add(new Occupation { ID = 6, Name = "Florist", RatingDetail = new RatingDetail { ID = 3 } });
            //
        }
        public List<Occupation> GetAllOccupations()
        {            
            List<Occupation> occupations = null;

            // ToDo:: _occupations will be fectched from datasource using EF
            occupations = _occupations;

            // If Occupation is null then
            if (occupations == null)
            {
                // Log -> Constants.OCCUPATION_NULL_ERROR;                
            }

            return occupations;
        }
        public Occupation GetOccupationByID(int id)
        {           
            Occupation occupation = null;

            // ToDo:: _occupations will be fectched from datasource using EF
            occupation = _occupations.FirstOrDefault(o => o.ID == id);

            // If Occupation or RatingDetails is null then
            if (occupation == null || occupation.RatingDetail == null)
            {
                // Log -> Constants.OCCUPATION_NULL_ERROR;               
            }
            else
            {
                // ToDo:: This won't be required, as EF will automap RatingDetail
                RatingDetail ratingDetail = _ratingDetailService.GetRatingDetailByID(occupation.RatingDetail.ID);
                occupation.RatingDetail = ratingDetail;
                //
            }

            return occupation;
        }              
    }
}
