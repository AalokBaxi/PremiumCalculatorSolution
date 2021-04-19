namespace PremiumCalculator.Core.Common
{
    public static class Constants
    {
        public const string OCCUPATION_ID_NULL_ERROR = "Occupation not selected, please try again.";
        public const string OCCUPATION_NULL_ERROR = "Unable to load occupations, please try again later.";
        public const string OCCUPATION_NOT_FOUND = "Unable to find occupation, please try again later.";

        public const string RATING_ID_NULL_ERROR = "Rating not selected, please try again.";
        public const string RATING_NULL_ERROR = "Unable to load ratings, please try again later.";
        public const string RATING_NOT_FOUND = "Unable to find occupation rating, please try again later.";
        
        public const string CALCULATOR_PARAMETER_NULL_ERROR = "No inputs provided for premium calculation.";
        public const string CALCULATOR_PARAMETER_DEATH_SUM_INSURED_NULL_ERROR = "Valid death sum insured amount not provided, please try again.";
        public const string CALCULATOR_PARAMETER_AGE_NULL_ERROR = "Valid age not provided, please try again";
        public const string PREMIUM_NULL = "Unable to calculate premium, please try again later.";
    }
}
