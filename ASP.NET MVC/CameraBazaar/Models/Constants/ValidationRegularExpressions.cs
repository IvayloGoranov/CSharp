namespace CameraBazaar.Models.Constants
{
    public class ValidationRegularExpressions
    {
        public const string PasswordRegex = "^[a-z0-9]{3,}$";
        public const string PhoneRegex = "^\\+[0-9]{10,12}$";
        public const string CameraModelRegex = "^[A-Z0-9-]+";
        public const string ImageUrlRegex = "^(http://|https://).+";

    }
}
