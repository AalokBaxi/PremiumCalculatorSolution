using PremiumCalculator.Core.Models;
using System.Collections.Generic;

namespace PremiumCalculator.Service.Services
{
    public interface IRatingDetailService
    {
        List<RatingDetail> GetAllRatingDetails();
        RatingDetail GetRatingDetailByID(int id);
    }
}
