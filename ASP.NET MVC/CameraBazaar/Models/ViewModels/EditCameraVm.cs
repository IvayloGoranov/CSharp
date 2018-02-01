using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Enums;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.ViewModels
{
    public class EditCameraVm
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required, RegularExpression(CameraModelRegex, ErrorMessage = CameraModelValidationMessage)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, Range(0, 100)]
        public int Quantity { get; set; }

        [Required, Range(1, 30)]
        [Display(Name = "Min shutter speed")]
        public int MinShutterSpeed { get; set; }

        [Required, Range(2000, 8000)]
        [Display(Name = "Max shutter speed")]
        public int MaxShutterSpeed { get; set; }

        [MinIso, Required]
        [Display(Name = "Min ISO")]
        public int MinIso { get; set; }

        [Required, Range(200, 409600), MaxIso]
        [Display(Name = "Max ISO")]
        public int MaxIso { get; set; }

        [Display(Name = "Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [Required, StringLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public LightMetering LightMetering { get; set; }

        [StringLength(6000), Required]
        public string Description { get; set; }

        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlMessage), Required]
        public string ImageUrl { get; set; }
    }
}
