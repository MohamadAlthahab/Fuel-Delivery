using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fuel_Delivery.Model
{
    public class CarDTO : UpdateCarDTO
    {
        [Required]
        public string CarModel { get; set; }
        [Required]
        public string CarNumber { get; set; }
        [Required]
        public string FuelCapacity { get; set; }
    }
    public class UpdateCarDTO
    {
        public string Location { get; set; }
        public double CurrentFuelCapacity { get; set; }
        public string Status { get; set; }
        public int FuelId { get; set; }
        public int DriverId { get; set; }
    }
}
