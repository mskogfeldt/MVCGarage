﻿using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Type of Vehicle")]
        public VehicleType Type { get; set; } = null!;
        [Display(Name = "Parked Time")]
        public string? RegistrationNumber { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Checkout Time")]
        public DateTime CheckoutTime { get; set; }
        [Display(Name = "Parked Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d\\d\\ hh\\h\\ mm\\m}")]
        public TimeSpan ParkedTime { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        [Display(Name = "Number of Wheels")]
        public int WheelCount { get; set; }
        public string? Model { get; set; }
        public Color Color { get; set; }

        public DateTime ProMembershipToDate { get; set; }
        public bool HasReceived2YearsProMembership { get; set; }

    }
}
