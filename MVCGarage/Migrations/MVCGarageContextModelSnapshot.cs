// <auto-generated />
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
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCGarage.Models.Entities.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WheelCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationNumber")
                        .IsUnique();

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2101),
                            Brand = "Volvo",
                            Color = 2,
                            Model = "240",
                            RegistrationNumber = "ABC123",
                            Type = 0,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2131),
                            Brand = "Saab",
                            Color = 1,
                            Model = "900",
                            RegistrationNumber = "BLA222",
                            Type = 0,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2134),
                            Brand = "BMW",
                            Color = 0,
                            Model = "320i",
                            RegistrationNumber = "ALB333",
                            Type = 0,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 4,
                            ArrivalTime = new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2137),
                            Brand = "Toyota",
                            Color = 2,
                            Model = "Yaris",
                            RegistrationNumber = "HEY332",
                            Type = 1,
                            WheelCount = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
