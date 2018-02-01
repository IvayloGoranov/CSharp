using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Globalization;

namespace BindingValidation
{
    class EGNValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"\A\d{10}\Z";
            if (Regex.IsMatch((string)value, pattern))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, 
                    "EGN should be a 10-digit number.");
            }
        }
    }
}
