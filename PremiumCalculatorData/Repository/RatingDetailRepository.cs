using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public class RatingDetailRepository : Repository<RatingDetail>, IRatingDetailRepository
    {
        public RatingDetailRepository(CalculatorContext calculatorContext) : base(calculatorContext) { }
        public List<RatingDetail> GetAllRatingDetails()
        {
            return GetAll().ToList();
        }

        public RatingDetail GetRatingDetailByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}