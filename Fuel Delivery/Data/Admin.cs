using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Data
{
    public class Admin : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
