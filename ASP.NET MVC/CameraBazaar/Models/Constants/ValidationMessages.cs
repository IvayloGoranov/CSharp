namespace CameraBazaar.Models.Constants
{
    public class ValidationMessages
    {
        public const string PasswordValidationMessage = "Password must be at least 3 sybols long and can only contain lowercase letters and digits. ";
        public const string PhoneValidationMessage = "Phone must statrt with \"+\" sign followed by 10 to 12 digits";
        public const string UsernameValidationMessage = "Value must be between 4 and 20 symbols long and must contain only letters.";
        public const string CameraModelValidationMessage = "Value can only contain uppercase letters, digits and dash.";
        public const string MinIsoValidationMessage = "Value must be 50 or 100";
        public const string MaxIsoValidationMessage = "Value must be dividable by 100";
        public const string ImageUrlMessage = "Value must start with http:// or https://";
    }
}
