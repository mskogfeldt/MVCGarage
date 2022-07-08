using MVCGarage.Models.Entities;

namespace MVCGarage.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public VehicleType Type { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public DateTime TotalParkedTime { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public Color Color { get; set; }
    }
}
