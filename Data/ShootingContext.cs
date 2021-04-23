using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shooting;

    public class ShootingContext : DbContext
    {
        public ShootingContext (DbContextOptions<ShootingContext> options)
            : base(options)
        {
        }

        public DbSet<Shooting.Manufacturer> Manufacturer { get; set; }

        public DbSet<Shooting.Firearm> Firearm { get; set; }

        public DbSet<Shooting.Chamber> Chamber { get; set; }

        public DbSet<Shooting.LoadData> LoadData { get; set; }
    }
