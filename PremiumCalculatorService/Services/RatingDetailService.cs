using PremiumCalculator.Core.Common;
using PremiumCalculator.Core.Models;
using PremiumCalculator.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Service.Services
{
    public class RatingDetailService : IRatingDetailService
    {
        private readonly List<RatingDetail> _ratingDetails;
        public RatingDetailService()
        {
            // This can come from repository using EF
            _ratingDetails = new List<RatingDetail>();
            _ratingDetails.Add(new RatingDetail { ID = 1, Name = "Professional", Factor = (decimal)1.0 });
            _ratingDetails.Add(new RatingDetail { ID = 2, Name = "White Collar", Factor = (decimal)1.25 });
            _ratingDetails.Add(new RatingDetail { ID = 3, Name = "Light Manual", Factor = (decimal)1.50 });
            _ratingDetails.Add(new RatingDetail { ID = 4, Name = "Heavy Manual", Factor = (decimal)1.75 });
            //
        }
        public List<RatingDetail> GetAllRatingDetails()
        {
            #region System validation
            if (_ratingDetails == null)
            {
                throw new Exception(Constants.RATING_NULL_ERROR);
            } 
            #endregion

            return _ratingDetails;
        }

        public RatingDetail GetRatingDetailByID(int id)
        {
            #region Business validations
            if (id <= 0)
            {
                // Log -> Constants.RATING_NULL_ERROR;               
                throw new BusinessException(Constants.RATING_ID_NULL_ERROR);
            }

            if (_ratingDetails == null)
            {
                // Log -> Constants.RATING_NOT_FOUND;   
                throw new BusinessException(Constants.RATING_NOT_FOUND);
            }
            #endregion

            return _ratingDetails.FirstOrDefault(o => o.ID == id);
        }
    }
}