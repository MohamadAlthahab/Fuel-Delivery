using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Data
{
    public class Fuel
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public Double Price { get; set; }
    }
}
