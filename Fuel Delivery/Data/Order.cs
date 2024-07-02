using System.ComponentModel.DataAnnotations.Schema;

namespace Fuel_Delivery.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string FuelType { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("DriverId")]
        public int DriverId { get; set; }

    }
}
