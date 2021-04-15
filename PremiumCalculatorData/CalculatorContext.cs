using Microsoft.EntityFrameworkCore;
using PremiumCalculatorCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext() { }
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
            LoadRatingDetails();
            LoadOccupations();
        }

        public DbSet<RatingDetail> RatingDetails { get; set; }
        public DbSet<Occupation> Occupations { get; set; }


        /// <summary>
        /// Load mock rating details
        /// </summary>
        private void LoadRatingDetails()
        {
            RatingDetails.Add(new RatingDetail { ID = 1, Name = "Professional", Factor = 1.0 });
            RatingDetails.Add(new RatingDetail { ID = 2, Name = "White Collar", Factor = 1.25 });
            RatingDetails.Add(new RatingDetail { ID = 3, Name = "Light Manual", Factor = 1.50 });
            RatingDetails.Add(new RatingDetail { ID = 4, Name = "Heavy Manual", Factor = 1.75 });
        }

        /// <summary>
        /// Load mock occupation
        /// </summary>
        private void LoadOccupations()
        {
            Occupations.Add(new Occupation { ID = 1, Name = "Cleaner", RatingID = 3 });
            Occupations.Add(new Occupation { ID = 2, Name = "Doctor", RatingID = 1 });
            Occupations.Add(new Occupation { ID = 3, Name = "Author", RatingID = 2 });
            Occupations.Add(new Occupation { ID = 4, Name = "Farmer", RatingID = 4 });
            Occupations.Add(new Occupation { ID = 5, Name = "Mechanic", RatingID = 4 });
            Occupations.Add(new Occupation { ID = 6, Name = "Florist", RatingID = 3 });
        }
    }
}