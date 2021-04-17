namespace PremiumCalculator.Core.Models
{
    public class CalculatorParameter
    {
        /// <summary>
        /// Your name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Your age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Your date of birth
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// Occupation ID
        /// </summary>
        public int OccupationID { get; set; }

        /// <summary>
        /// Sum assured required
        /// </summary>
        public decimal DeathSumInsured { get; set; }
    }
}