using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<IndexParkedVehicleViewModel>? VehicleList { get; set; }
        [MaxLength(50)]
        [Display(Name = "Registration Number")]
        public string? SearchRegistrationNumber { get; set; }
        [Display(Name = "Brand")]
        public string? SearchBrand { get; set; }
        [Display(Name = "Model")]
        public string? SearchModel { get; set; }
        [Display(Name = "Wheel Count")]
        public int? SearchWheelCount { get; set; }
        [Display(Name = "Type")]
        public VehicleType? SearchType { get; set; }
        public Order? Order { get; set; }

        public bool Desc { get; set; } = false;
    }

    public enum Order
    {
        ArrivalTime,
        RegistrationNumber,
        Type,
        ParkedTime
    }
}
