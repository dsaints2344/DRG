using DRG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Persistence
{
    public class DataContext : DbContext
    {
        private const string connectionString = "Server=127.0.0.1,1433;Database=DRG;User Id=SA;;Password=yourStrong(!)Password;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<CHIRPHospital> CHIRPHospitals { get; set;}
        public DbSet<HospitalRate> HospitalRates { get; set;}
        public DbSet<Weight> Weights { get; set; }

    }
}
