using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Model
{
    public class FuelDTO
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public Double Price { get; set; }
    }
}
