using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Model
{
    public class DriverDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone nember")]
        public string Phone { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        [StringLength (11)]
        [RegularExpression("^([0-9]{11})$", ErrorMessage ="Invalid ID Nember")]
        public string IDNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
