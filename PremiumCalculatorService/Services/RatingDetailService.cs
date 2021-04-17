using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Service.Services
{
    public class RatingDetailService : IRatingDetailService
    {
        private readonly List<RatingDetail> ratingDetails;
        public RatingDetailService()
        {
            // This can come from repository using EF
            ratingDetails = new List<RatingDetail>();
            ratingDetails.Add(new RatingDetail { ID = 1, Name = "Professional", Factor = (decimal)1.0 });
            ratingDetails.Add(new RatingDetail { ID = 2, Name = "White Collar", Factor = (decimal)1.25 });
            ratingDetails.Add(new RatingDetail { ID = 3, Name = "Light Manual", Factor = (decimal)1.50 });
            ratingDetails.Add(new RatingDetail { ID = 4, Name = "Heavy Manual", Factor = (decimal)1.75 });
            //
        }
        public List<RatingDetail> GetAllRatingDetails()
        {
            if (ratingDetails == null)
            {
                throw new Exception(Constants.RATING_NULL_ERROR);
            }

            return ratingDetails;
        }

        public RatingDetail GetRatingDetailByID(int id)
        {
            if (ratingDetails == null)
            {
                throw new Exception(Constants.RATING_NULL_ERROR);
            }

            return ratingDetails.FirstOrDefault(o => o.ID == id);
        }
    }
}