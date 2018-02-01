using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.Attributes
{
    public class MinIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int iso = (int)value;

            if (iso == 50 || iso == 100)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(MinIsoValidationMessage);
        }
    }
}
