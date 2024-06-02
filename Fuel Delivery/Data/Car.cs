using System.ComponentModel.DataAnnotations.Schema;

namespace Fuel_Delivery.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string  CarModel { get; set; }
        public string CarNumber { get; set; }
        public string FuelCapacity { get; set; }
        public string Location { get; set; }
        public double CurrentFuelCapacity { get; set; }
        public string Status { get; set; }

        [ForeignKey("FuelId")]
        public int FuelId { get; set; }

        [ForeignKey("DriverId")]
        public int DriverId { get; set; }
    }
}
