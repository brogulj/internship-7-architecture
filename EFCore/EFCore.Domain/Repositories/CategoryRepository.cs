using EFCore.Data.Entities;
using EFCore.Data.Entities.Models;
using EFCore.Domain.Enums;
using System.Linq;

namespace EFCore.Domain.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(Category category)
        {
            var categories = DbContext.Categories.ToList();
            foreach (var categoryDb in categories)
            {
                if (categoryDb.Name == category.Name)
                {
                    return ResponseResultType.ValidationError;
                }
            }
            DbContext.Categories.Add(category);
            return SaveChanges();
        }
        public ResponseResultType Rename(string name, int categoryId)
        {
            var categories = DbContext.Categories.ToList();
            foreach (var categoryDb in categories)
            {
                if (categoryDb.Name == name)
                {
                    return ResponseResultType.ValidationError;
                }
            }
            var category = DbContext.Categories.Find(categoryId);
            category.Name = name;
            return SaveChanges();
        }
        public ResponseResultType Delete(int categoryId)
        {
            var category = DbContext.Categories.Find(categoryId);
            if (category == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Categories.Remove(category);
            return SaveChanges();
        }
        public Category FindById(int Id)
        {
            return DbContext.Categories
                .Find(Id);
        }
        public ResponseResultType AddLink(int categoryId, int offerId)
        {
            var category = FindById(categoryId);
            if(category == null)
            {
                return ResponseResultType.NotFound;
            }
            var offer = DbContext.Offers.Find(offerId);
            if (offer.Categories.Contains(category))
            {
                return ResponseResultType.ValidationError;
            }
            offer.Categories.Add(category);
            category.Offers.Add(offer);
            return SaveChanges();
        }
        public int FindIdBYName(string name)
        {
            foreach (var category in DbContext.Categories.ToList())
            {
                if (category.Name.ToLower() == name.ToLower())
                {
                    return category.Id;
                }
            }
            return 0;
        }
    }
}
