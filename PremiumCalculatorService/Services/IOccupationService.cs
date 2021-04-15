using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Service
{
    public interface IOccupationService
    {
        List<Occupation> GetAllOccupations();
        Occupation GetOccupationByID(int id);
    }
}
