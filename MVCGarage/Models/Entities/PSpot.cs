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
        }
        public int Id { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
