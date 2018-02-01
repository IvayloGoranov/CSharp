using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.Attributes
{
    public class MaxIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int iso = (int)value;

            if (iso % 100 == 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(MaxIsoValidationMessage);
        }
    }
}
