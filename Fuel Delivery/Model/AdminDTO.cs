using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Model
{
    public class AdminDTO
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
