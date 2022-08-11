﻿// <auto-generated />
using System;
using MVCGarage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCGarage.Migrations
{
    [DbContext(typeof(MVCGarageContext))]
    partial class MVCGarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCGarage.Models.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("HasReceived2YearsProMembership")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalIdentityNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("ProMembershipToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonalIdentityNumber")
                        .IsUnique();

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Kalle",
                            HasReceived2YearsProMembership = false,
                            LastName = "Larsson",
                            PersonalIdentityNumber = "19810701-6666",
                            ProMembershipToDate = new DateTime(2022, 9, 10, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9868)
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Kolle",
                            HasReceived2YearsProMembership = false,
                            LastName = "Persson",
                            PersonalIdentityNumber = "19810702-6666",
                            ProMembershipToDate = new DateTime(2022, 9, 5, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9902)
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Koklan",
                            HasReceived2YearsProMembership = false,
                            LastName = "Sigvardsson",
                            PersonalIdentityNumber = "19810703-6666",
                            ProMembershipToDate = new DateTime(2022, 8, 26, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9904)
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Kille",
                            HasReceived2YearsProMembership = false,
                            LastName = "Andersson",
                            PersonalIdentityNumber = "19810704-6666",
                            ProMembershipToDate = new DateTime(2022, 8, 21, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9906)
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Ablin",
                            HasReceived2YearsProMembership = false,
                            LastName = "Dahlstedt",
                            PersonalIdentityNumber = "19810705-6666",
                            ProMembershipToDate = new DateTime(2022, 8, 16, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9908)
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Sara",
                            HasReceived2YearsProMembership = false,
                            LastName = "Larsson",
                            PersonalIdentityNumber = "19810706-6666",
                            ProMembershipToDate = new DateTime(2022, 8, 18, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9910)
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "FlygAnders",
                            HasReceived2YearsProMembership = true,
                            LastName = "Highlander",
                            PersonalIdentityNumber = "19010101-6666",
                            ProMembershipToDate = new DateTime(2022, 8, 1, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9912)
                        });
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.PSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("PSpot");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        },
                        new
                        {
                            Id = 4
                        },
                        new
                        {
                            Id = 5
                        },
                        new
                        {
                            Id = 6
                        },
                        new
                        {
                            Id = 7
                        },
                        new
                        {
                            Id = 8
                        },
                        new
                        {
                            Id = 9
                        },
                        new
                        {
                            Id = 10
                        });
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WheelCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RegistrationNumber")
                        .IsUnique();

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Volvo",
                            Color = 2,
                            MemberId = 1,
                            Model = "240",
                            RegistrationNumber = "ABC123",
                            VehicleTypeId = 1,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Saab",
                            Color = 1,
                            MemberId = 1,
                            Model = "900",
                            RegistrationNumber = "BLA222",
                            VehicleTypeId = 1,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 3,
                            Brand = "BMW",
                            Color = 0,
                            MemberId = 1,
                            Model = "320i",
                            RegistrationNumber = "ALB333",
                            VehicleTypeId = 1,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Honda",
                            Color = 2,
                            MemberId = 2,
                            Model = "MT-07",
                            RegistrationNumber = "MOT123",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Yamaha",
                            Color = 5,
                            MemberId = 2,
                            Model = "XT500",
                            RegistrationNumber = "YAM456",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Suzuki",
                            Color = 2,
                            MemberId = 2,
                            Model = "350",
                            RegistrationNumber = "SUZ111",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Honda",
                            Color = 6,
                            MemberId = 3,
                            Model = "MT-07",
                            RegistrationNumber = "MOT456",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Yamaha",
                            Color = 4,
                            MemberId = 3,
                            Model = "XT500",
                            RegistrationNumber = "YAM789",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Suzuki",
                            Color = 1,
                            MemberId = 3,
                            Model = "750",
                            RegistrationNumber = "SUZ222",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Honda",
                            Color = 0,
                            MemberId = 4,
                            Model = "MT-07",
                            RegistrationNumber = "MOT777",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 11,
                            Brand = "Yamaha",
                            Color = 3,
                            MemberId = 4,
                            Model = "XT500",
                            RegistrationNumber = "YAM888",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 12,
                            Brand = "Suzuki",
                            Color = 7,
                            MemberId = 4,
                            Model = "1050",
                            RegistrationNumber = "SUZ333",
                            VehicleTypeId = 2,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Boeing",
                            Color = 6,
                            MemberId = 7,
                            Model = "C-73",
                            RegistrationNumber = "FFF111",
                            VehicleTypeId = 3,
                            WheelCount = 2
                        });
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.VehicleAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int>("PSpotId")
                        .HasColumnType("int")
                        .HasColumnName("PSpotsPSpotId");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VehiclesVehicleId()");

                    b.HasKey("Id");

                    b.HasIndex("PSpotId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleAssignment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalDate = new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3145),
                            PSpotId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalDate = new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3156),
                            PSpotId = 2,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArrivalDate = new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3158),
                            PSpotId = 3,
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("NeededSize")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Car",
                            NeededSize = 1f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Motorcycle",
                            NeededSize = 0.33f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Airplane",
                            NeededSize = 8f
                        });
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.Vehicle", b =>
                {
                    b.HasOne("MVCGarage.Models.Entities.Member", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCGarage.Models.Entities.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.VehicleAssignment", b =>
                {
                    b.HasOne("MVCGarage.Models.Entities.PSpot", "PSpot")
                        .WithMany("VehicleAssignments")
                        .HasForeignKey("PSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCGarage.Models.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleAssignments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PSpot");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.Member", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.PSpot", b =>
                {
                    b.Navigation("VehicleAssignments");
                });

            modelBuilder.Entity("MVCGarage.Models.Entities.Vehicle", b =>
                {
                    b.Navigation("VehicleAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
