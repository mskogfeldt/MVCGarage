using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public VehicleType Type { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        [Display(Name = "Parked Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d\\d\\ hh\\h\\ mm\\m}")]
        public TimeSpan ParkedTime { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public Color Color { get; set; }
    }
}
