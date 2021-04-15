using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public interface IRatingDetailRepository : IRepository<RatingDetail>
    {
        List<RatingDetail> GetAllRatingDetails();
        RatingDetail GetRatingDetailByID(int id);
    }
}
