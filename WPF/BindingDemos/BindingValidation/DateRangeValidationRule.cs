using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Globalization;

namespace BindingValidation
{
    class DateRangeValidationRule : ValidationRule
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string DateFormat { get; set; }

        public DateRangeValidationRule()
        {
            this.MinDate = DateTime.Now.AddYears(-10);
            this.MaxDate = DateTime.Now.AddYears(10);
            this.DateFormat = "dd/MM/yyyy";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime parsedDate;
            bool parsed = DateTime.TryParseExact(
                (string)value, this.DateFormat, cultureInfo,
                DateTimeStyles.AllowInnerWhite, out parsedDate);
            if (!parsed)
            {
                return new ValidationResult(false,
                    "Invalid date format. Please use " + this.DateFormat + ".");
            }
            if ((parsedDate < this.MinDate) || (parsedDate > this.MaxDate))
            {
                return new ValidationResult(false, String.Format(
                    "The date should be between {0:" + this.DateFormat + 
                    "} and {1:" + this.DateFormat +"}.", 
                    this.MinDate, this.MaxDate));
            }

            return new ValidationResult(true, null);
        }
    }
}
