using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;

namespace MVCGarage.Data
{
    public class MVCGarageContext : DbContext
    {
        public MVCGarageContext (DbContextOptions<MVCGarageContext> options)
            : base(options)
        {
        }

        public DbSet<MVCGarage.Models.Entities.ParkedVehicle>? ParkedVehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParkedVehicle>().HasData(
                new ParkedVehicle {Id = 1, Brand = "Volvo", Color = Color.Yellow, Model = "240", RegistrationNumber = "ABC-123", Type = VehicleType.Car, WheelCount = 4, ArrivalTime = DateTime.Now }
            );
        }
    }
}
