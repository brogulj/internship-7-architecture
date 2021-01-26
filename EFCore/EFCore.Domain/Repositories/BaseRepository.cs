using EFCore.Data.Entities;
using EFCore.Domain.Enums;

namespace EFCore.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly EFCoreDbContext DbContext;

        protected BaseRepository(EFCoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}
