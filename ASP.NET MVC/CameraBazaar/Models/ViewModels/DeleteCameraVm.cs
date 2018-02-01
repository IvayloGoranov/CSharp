using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Enums;

namespace CameraBazaar.Models.ViewModels
{
    public class DeleteCameraVm
    {
        public Make Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Min shutter speed")]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max shutter speed")]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO")]
        public int MinIso { get; set; }

        [Display(Name = "Max ISO")]
        public int MaxIso { get; set; }

        [Display(Name = "Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public LightMetering LightMetering { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}
