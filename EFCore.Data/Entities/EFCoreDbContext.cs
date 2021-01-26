using EFCore.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace EFCore.Data.Entities
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataBaseSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class EFCoreContextFactory : IDesignTimeDbContextFactory<EFCoreDbContext>
    {
        public EFCoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();
            configuration
                .Providers
                .First()
                .TryGet("connectionStrings:add:RentACar:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<EFCoreDbContext>().UseSqlServer(connectionString).Options;
            return new EFCoreDbContext(options);
        }
    }
}


