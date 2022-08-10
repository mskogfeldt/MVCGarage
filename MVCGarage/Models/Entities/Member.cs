using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.Entities
{
    [Index(nameof(PersonalIdentityNumber), IsUnique = true)]
    public class Member
    {
        public Member()
        {
            Vehicles = new List<Vehicle>();
        }
        public int Id { get; set; }
        [Required]
        public DateTime ProMembershipToDate { get; set; }
        [Required] 
        [StringLength(13)]
        //TODO make similar uniquecheck? [Remote(action: "CheckIfRegIsUnique", controller: "Vehicles")]
        public string? PersonalIdentityNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        public bool HasReceived2YearsProMembership { get; set; }

        //Nav prop
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
