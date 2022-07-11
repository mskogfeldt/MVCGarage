using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<IndexParkedVehicleViewModel>? VehicleList { get; set; }
        [MaxLength(50)]
        [Display(Name = "Registration Number")]
        public string? searchRegistrationNumber { get; set; }
        [Display(Name = "Brand")]
        public string? searchBrand { get; set; }
        [Display(Name = "Model")]
        public string? searchModel { get; set; }
        [Display(Name = "Wheel Count")]
        public int? searchWheelCount { get; set; }
        [Display(Name = "Type")]
        public VehicleType? searchType { get; set; }      
    }
}
