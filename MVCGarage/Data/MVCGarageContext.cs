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
                new ParkedVehicle {Id = 1, Brand = "Volvo", Color = Color.Yellow, Model = "240", RegistrationNumber = "ABC123", Type = VehicleType.Car, WheelCount = 4, ArrivalTime = DateTime.Now },
                new ParkedVehicle {Id = 2, Brand = "Saab", Color = Color.Blue, Model = "900", RegistrationNumber = "BLA222", Type = VehicleType.Car, WheelCount = 4, ArrivalTime = DateTime.Now },
                new ParkedVehicle {Id = 3, Brand = "BMW", Color = Color.Red, Model = "320i", RegistrationNumber = "ALB333", Type = VehicleType.Car, WheelCount = 4, ArrivalTime = DateTime.Now },
                new ParkedVehicle {Id = 4, Brand = "Toyota", Color = Color.Yellow, Model = "Yaris", RegistrationNumber = "HEY332", Type = VehicleType.Airplane, WheelCount = 3, ArrivalTime = DateTime.Now }
            );

            //modelBuilder.Entity<ParkedVehicle>()
            //    .HasIndex(pv => pv.RegistrationNumber)
            //    .IsUnique();

            //modelBuilder.Entity<ParkedVehicle>()
            //    .HasAlternateKey(a => a.RegistrationNumber);

        }
    }
}
