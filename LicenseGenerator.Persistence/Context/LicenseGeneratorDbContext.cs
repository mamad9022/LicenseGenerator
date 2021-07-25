using System.Threading.Tasks;
using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseGenerator.Persistence.Context
{
    public class LicenseGeneratorDbContext : DbContext, ILicenseGeneratorDbContext
    {
        public LicenseGeneratorDbContext()
        {

        }
        public LicenseGeneratorDbContext(DbContextOptions<LicenseGeneratorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<LicenseLog> LicenseLogs { get; set; }

        public Task SaveAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer(
                    @"Server=.;Initial Catalog=LicenseDb;MultipleActiveResultSets=true;Integrated Security=True;User Id=sa;Password=AbC123_-");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LicenseGeneratorDbContext).Assembly);
        }
    }
}
