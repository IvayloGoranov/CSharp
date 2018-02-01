using System;

namespace DataValidation.Attributes
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MinLengthAttribute : ValidationAttribute
    {
        private int minLength;

        public MinLengthAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return valueAsString != null && valueAsString.Length >= this.minLength;
        }
    }
}