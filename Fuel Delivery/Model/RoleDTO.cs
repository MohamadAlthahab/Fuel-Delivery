using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Model
{
    public class CreateRoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
    public class RoleDTO : CreateRoleDTO
    {
        public int Id { get; set; }
    }
}
