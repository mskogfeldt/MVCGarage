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
    }
}
