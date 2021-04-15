using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();
    }
}
