using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private CalculatorContext _calculatorContext;
        public Repository(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }
        public IQueryable<T> GetAll()
        {
            return _calculatorContext.Set<T>();
        }
    }
}
