using MVCGarage.Models.Entities;


namespace MVCGarage.Models.ViewModels
{
    public class ParkedVehicleViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
