using MVCGarage.Models.Entities;


namespace MVCGarage.Models.ViewModels
{
    public class IndexParkedVehicleViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
