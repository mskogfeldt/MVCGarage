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

        public DbSet<Vehicle> Vehicle => Set<Vehicle>();
        public DbSet<VehicleType> VehicleType => Set<VehicleType>();
        public DbSet<VehicleAssignment> VehicleAssignment => Set<VehicleAssignment>();
        public DbSet<Member> Member => Set<Member>();
        public DbSet<PSpot> PSpot => Set<PSpot>();

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
                new VehicleType { Id = 2, Name = "Motorcycle", NeededSize = 0.33f },
                new VehicleType { Id = 3, Name = "Airplane", NeededSize = 8 }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, FirstName = "Kalle", HasReceived2YearsProMembership = false, LastName = "Larsson", PersonalIdentityNumber = "19810701-2018", ProMembershipToDate = DateTime.Today.AddDays(30) },
                new Member { Id = 2, FirstName = "Kolle", HasReceived2YearsProMembership = false, LastName = "Persson", PersonalIdentityNumber = "19810702-4351", ProMembershipToDate = DateTime.Today.AddDays(25) },
                new Member { Id = 3, FirstName = "Koklan", HasReceived2YearsProMembership = false, LastName = "Sigvardsson", PersonalIdentityNumber = "19810703-0614", ProMembershipToDate = DateTime.Today.AddDays(15) },
                new Member { Id = 4, FirstName = "Kille", HasReceived2YearsProMembership = false, LastName = "Andersson", PersonalIdentityNumber = "19810704-0373", ProMembershipToDate = DateTime.Today.AddDays(10) },
                new Member { Id = 5, FirstName = "Ablin", HasReceived2YearsProMembership = false, LastName = "Dahlstedt", PersonalIdentityNumber = "19810705-5330", ProMembershipToDate = DateTime.Today.AddDays(5) },
                new Member { Id = 6, FirstName = "Sara", HasReceived2YearsProMembership = false, LastName = "Larsson", PersonalIdentityNumber = "19810706-5016", ProMembershipToDate = DateTime.Today.AddDays(7) },
                new Member { Id = 7, FirstName = "FlygAnders", HasReceived2YearsProMembership = true, LastName = "Highlander", PersonalIdentityNumber = "19010101-3530", ProMembershipToDate = DateTime.Today.AddDays(-10) }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Brand = "Volvo", Color = Color.Yellow, Model = "240", RegistrationNumber = "ABC123", VehicleTypeId=1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 2, Brand = "Saab", Color = Color.Blue, Model = "900", RegistrationNumber = "BLA222", VehicleTypeId = 1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 3, Brand = "BMW", Color = Color.Red, Model = "320i", RegistrationNumber = "ALB333", VehicleTypeId = 1, WheelCount = 4, MemberId = 1 },
                new Vehicle { Id = 4, Brand = "Honda", Color = Color.Yellow, Model = "MT-07", RegistrationNumber = "MOT123", VehicleTypeId = 2, WheelCount = 2, MemberId = 2 },
                new Vehicle { Id = 5, Brand = "Yamaha", Color = Color.Black, Model = "XT500", RegistrationNumber = "YAM456", VehicleTypeId = 2, WheelCount = 2, MemberId = 2 },
                new Vehicle { Id = 6, Brand = "Suzuki", Color = Color.Yellow, Model = "350", RegistrationNumber = "SUZ111", VehicleTypeId = 2, WheelCount = 2, MemberId = 2 },
                new Vehicle { Id = 7, Brand = "Honda", Color = Color.White, Model = "MT-07", RegistrationNumber = "MOT456", VehicleTypeId = 2, WheelCount = 2, MemberId = 3 },
                new Vehicle { Id = 8, Brand = "Yamaha", Color = Color.Brown, Model = "XT500", RegistrationNumber = "YAM789", VehicleTypeId = 2, WheelCount = 2, MemberId = 3 },
                new Vehicle { Id = 9, Brand = "Suzuki", Color = Color.Blue, Model = "750", RegistrationNumber = "SUZ222", VehicleTypeId = 2, WheelCount = 2, MemberId = 3 },
                new Vehicle { Id = 10, Brand = "Honda", Color = Color.Red, Model = "MT-07", RegistrationNumber = "MOT777", VehicleTypeId = 2, WheelCount = 2, MemberId = 4 },
                new Vehicle { Id = 11, Brand = "Yamaha", Color = Color.Green, Model = "XT500", RegistrationNumber = "YAM888", VehicleTypeId = 2, WheelCount = 2, MemberId = 4 },
                new Vehicle { Id = 12, Brand = "Suzuki", Color = Color.Other, Model = "1050", RegistrationNumber = "SUZ333", VehicleTypeId = 2, WheelCount = 2, MemberId = 4 },
                new Vehicle { Id = 13, Brand = "Boeing", Color = Color.White, Model = "C-73", RegistrationNumber = "FFF111", VehicleTypeId = 3, WheelCount = 2, MemberId = 7 }
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

            modelBuilder.Entity<VehicleAssignment>().HasData(
                new VehicleAssignment { Id = 1, ArrivalDate = DateTime.Now, PSpotId = 1, VehicleId = 1 },
                new VehicleAssignment { Id = 2, ArrivalDate = DateTime.Now, PSpotId = 2, VehicleId = 2 },
                new VehicleAssignment { Id = 3, ArrivalDate = DateTime.Now, PSpotId = 3, VehicleId = 3 }
            );



            //modelBuilder.Entity<Vehicle>()
            //    .HasIndex(pv => pv.RegistrationNumber)
            //    .IsUnique();

            //modelBuilder.Entity<Vehicle>()
            //    .HasAlternateKey(a => a.RegistrationNumber);

        }
    }
}
