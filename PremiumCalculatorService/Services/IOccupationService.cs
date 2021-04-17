using PremiumCalculator.Core.Models;
using System.Collections.Generic;

namespace PremiumCalculator.Service.Services
{
    public interface IOccupationService
    {
        List<Occupation> GetAllOccupations();
        Occupation GetOccupationByID(int id);
    }
}
