using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PremiumCalculator.Data.Models
{
    public class CalculatorParameter
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your name")]
        //[StringLength(50, ErrorMessage = "Please provide valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide your age")]
        //[MinLength(1, ErrorMessage = "Please provide valid age")]
        //[MaxLength(200, ErrorMessage = "Please provide valid age")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your date of birth in dd/MM/yyyy format")]
        //[StringLength(10, ErrorMessage = "Please provide valid date of birth in dd/MM/yyyy format")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please provide your occupation")]        
        public OccupationName Occupation { get; set; }

        [Required(ErrorMessage = "Please provide sum assured required")]
        //[MinLength(1, ErrorMessage = "Please provide valid sum assured required")]
        //[MaxLength(50000000, ErrorMessage = "Please provide valid sum assured required")]
        public decimal DeathSumInsured { get; set; }
    }
}