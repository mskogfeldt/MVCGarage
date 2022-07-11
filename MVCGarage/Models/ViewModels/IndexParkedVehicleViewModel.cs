    using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class IndexParkedVehicleViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        [Display(Name = "Registration Number")]
        public string? RegistrationNumber { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Parked Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d\\d\\ hh\\h\\ mm\\m}")]
        public TimeSpan ParkedTime { get; set; }

    }
}
