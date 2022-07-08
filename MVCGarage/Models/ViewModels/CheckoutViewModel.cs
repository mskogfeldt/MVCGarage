using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public string? TotalParkedTime { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public int WheelCount { get; set; }
        public string? Model { get; set; }
        public Color Color { get; set; }
    }
}
