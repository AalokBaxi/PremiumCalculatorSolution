using PremiumCalculator.Data.Repository;
using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Service
{
    public class OccupationService : IOccupationService
    {
        private IOccupationRepository _occupationRepository;
        public OccupationService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }
        public List<Occupation> GetAllOccupations()
        {
            return _occupationRepository.GetAllOccupations();
        }

        public Occupation GetOccupationByID(int id)
        {
            return _occupationRepository.GetOccupationByID(id);
        }
    }
}
