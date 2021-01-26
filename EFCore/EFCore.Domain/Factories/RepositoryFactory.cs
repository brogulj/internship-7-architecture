using System;
using EFCore.Domain.Repositories;

namespace EFCore.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepository<TRepository>() where TRepository : BaseRepository
        {
            var context = DbContextFactory.GetEFCoreDbContext();
            return (TRepository)Activator.CreateInstance(typeof(TRepository), context);
        }
    }
}
