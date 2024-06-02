using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Data
{
    public class Driver : IdentityUser
    {
        [Key]
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string IDNumber { get; set; }
    }
}
