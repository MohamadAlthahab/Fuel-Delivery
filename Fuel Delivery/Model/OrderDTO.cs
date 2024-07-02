using System.ComponentModel.DataAnnotations.Schema;

namespace Fuel_Delivery.Model
{
    public class OrderDTO
    {
        public string Location { get; set; }
        public string FuelType { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int DriverId { get; set; }
    }
}
