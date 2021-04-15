using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(CalculatorContext calculatorContext) : base(calculatorContext) { }
        public List<Occupation> GetAllOccupations()
        {
            return GetAll().ToList();
        }

        public Occupation GetOccupationByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}