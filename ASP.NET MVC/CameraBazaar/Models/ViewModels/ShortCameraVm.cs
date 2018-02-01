namespace CameraBazaar.Models.ViewModels
{
    public class ShortCameraVm
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
