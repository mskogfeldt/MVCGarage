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

        public DbSet<Vehicle>? Vehicle { get; set; }
        public DbSet<VehicleType>? VehicleType { get; set; }
        public DbSet<VehicleAssignment>? VehicleAssignment { get; set; }
        public DbSet<Member>? Member { get; set; }
        public DbSet<PSpot>? PSpot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO:ReadFromConfig how big garage we want
            modelBuilder.Entity<PSpot>().HasData(
                new PSpot { Id = 1},
                new PSpot { Id = 2},
                new PSpot { Id = 3},
                new PSpot { Id = 4},
                new PSpot { Id = 5},
                new PSpot { Id = 6},
                new PSpot { Id = 7},
                new PSpot { Id = 8},
                new PSpot { Id = 9},
                new PSpot { Id = 10}
            );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Car", NeededSize = 1 },
                new VehicleType { Id = 2, Name = "Motorcycle", NeededSize = 0.33f }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, FirstName = "Kalle", HasReceived2YearsProMembership = false, LastName = "Larsson", PersonalIdentityNumber = "19810701-6666", ProMembershipToDate = DateTime.Now.AddDays(30) }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Brand = "Volvo", Color = Color.Yellow, Model = "240", RegistrationNumber = "ABC123", VehicleTypeId=1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 2, Brand = "Saab", Color = Color.Blue, Model = "900", RegistrationNumber = "BLA222", VehicleTypeId = 1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 3, Brand = "BMW", Color = Color.Red, Model = "320i", RegistrationNumber = "ALB333", VehicleTypeId = 1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 4, Brand = "Toyota", Color = Color.Yellow, Model = "Yaris", RegistrationNumber = "HEY332", VehicleTypeId = 1, WheelCount = 3, MemberId = 1 }
            );

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.PSpots)
                .WithMany(s => s.Vehicles)
                .UsingEntity<VehicleAssignment>(
                va => va.HasOne(va => va.PSpot).WithMany(v => v.VehicleAssignments),
                va => va.HasOne(va => va.Vehicle).WithMany(v => v.VehicleAssignments));


            modelBuilder.Entity<VehicleAssignment>()
                .Property(va => va.ArrivalDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<VehicleAssignment>()
                .Property(va => va.PSpotId).HasColumnName("PSpotsPSpotId");
            modelBuilder.Entity<VehicleAssignment>()
                .Property(va => va.VehicleId).HasColumnName("VehiclesVehicleId()");





            //modelBuilder.Entity<Vehicle>()
            //    .HasIndex(pv => pv.RegistrationNumber)
            //    .IsUnique();

            //modelBuilder.Entity<Vehicle>()
            //    .HasAlternateKey(a => a.RegistrationNumber);

        }
    }
}
