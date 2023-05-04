using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCars.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcCars.Data
{
    public class CarContext : IdentityDbContext
    {
        public CarContext (DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCars.Models.Car> Car { get; set; } = default!;

        public DbSet<MvcCars.Models.Marca> Marca { get; set; } = default!;
        public DbSet<MvcCars.Models.Accesory> Accesory { get; set; } = default!;
    }
}
