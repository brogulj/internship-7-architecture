using System.Configuration;
using EFCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain.Factories
{
    public static class DbContextFactory
    {
        public static EFCoreDbContext GetEFCoreDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["EFCore"].ConnectionString).Options;
            return new EFCoreDbContext(options);
        }
    }
}
