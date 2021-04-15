using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public interface IOccupationRepository : IRepository<Occupation>
    {
        List<Occupation> GetAllOccupations();
        Occupation GetOccupationByID(int id);
    }
}
