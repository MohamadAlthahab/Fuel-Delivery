using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fuel_Delivery.Model
{
    public class CarDTO
    {
        [Required]
        public string CarModel { get; set; }
        [Required]
        public string CarNumber { get; set; }
        [Required]
        public string FuelCapacity { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double CurrentFuelCapacity { get; set; }
        public string Status { get; set; }
        [Required]
        public int FuelId { get; set; }
        [Required]
        public int DriverId { get; set; }
    }
}
