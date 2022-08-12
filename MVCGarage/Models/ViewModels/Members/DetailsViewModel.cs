using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            Vehicles = new List<MemberVehicleModel>();
        }
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public Membership.MembershipType Type { get; set; }
        public List<MemberVehicleModel> Vehicles { get; set; }
        public int? VehicleId { get; set; }

        public bool? ParkSuccess { get; set; }
        public string? ParkFailedReason { get; set; }
        public string? modalTitleText { get; set; }
        public string? modalBodyText { get; set; }
    }
}
