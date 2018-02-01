using System.Collections.Generic;
using CarDealer.Models.ViewModels.Parts;

namespace CarDealer.Models.ViewModels.Cars
{
    public class AboutCarVm
    {
        public CarVm Car { get; set; }

        public IEnumerable<PartVm> Parts { get; set; }
    }
}
