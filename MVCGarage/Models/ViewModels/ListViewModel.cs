using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<IndexVehicleViewModel> VehicleList { get; set; } = new List<IndexVehicleViewModel>();
        [MaxLength(50)]
        [Display(Name = "Registration Number")]
        public string? SearchRegistrationNumber { get; set; }
        [Display(Name = "Brand")]
        public string? SearchBrand { get; set; }
        [Display(Name = "Model")]
        public string? SearchModel { get; set; }
        [Display(Name = "Number of Wheels")]
        public int? SearchWheelCount { get; set; }
        [Display(Name = "Type of Vehicle")]
        public VehicleType? SearchType { get; set; }
        public Order? Order { get; set; }
        public bool Desc { get; set; } = false;
        public bool HasSearchItem { get; set; } = false;
    }

    public enum Order
    {
        ArrivalTime,
        RegistrationNumber,
        Type,
        ParkedTime
    }
}
