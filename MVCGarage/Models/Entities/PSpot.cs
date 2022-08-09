using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.Entities
{
    public class PSpot
    {
        public PSpot()
        {
            Vehicles = new List<Vehicle>();
            VehicleAssignments = new List<VehicleAssignment>();
        }
        public int Id { get; set; }

        //Nav prop
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<VehicleAssignment> VehicleAssignments { get; set; }
    }
}
