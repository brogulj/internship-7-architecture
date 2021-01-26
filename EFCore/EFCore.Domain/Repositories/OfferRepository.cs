using EFCore.Data.Entities;
using EFCore.Data.Entities.Models;
using EFCore.Data.Enums;
using EFCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Repositories
{
    public class OfferRepository : BaseRepository
    {
        public OfferRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(Offer offer)
        {
            var offers = DbContext.Offers.ToList();
            foreach (var offerDb in offers)
            {
                if (offerDb.Name == offer.Name)
                {
                    return ResponseResultType.ValidationError;
                }
            }
            offer.Employee = DbContext.Employees.Find(offer.EmployeeId);
            DbContext.Offers.Add(offer);
            return SaveChanges();
        }
        public ResponseResultType Edit(Offer offer, int offerId)
        {
            var offerDb = DbContext.Offers.Find(offerId);
            if (offerDb == null)
            {
                return ResponseResultType.NotFound;
            }
            offerDb.Name = offer.Name;
            offerDb.Price = offer.Price;
            offerDb.AmmountLeft = offer.AmmountLeft;
            offerDb.AmmountSold = offer.AmmountSold;
            offerDb.Availability = offer.Availability;
            offerDb.SaleType = offer.SaleType;
            offerDb.Categories = offer.Categories;
            return SaveChanges();
        }
        public ICollection<Offer> GetByType(SaleType saleType) 
        {
            return DbContext.Offers
                .Where(o => o.SaleType == saleType)
                .ToList();
        }
        public ResponseResultType Delete(int offerId)
        {
            var offer = DbContext.Offers.Find(offerId);
            if (offer == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Offers.Remove(offer);
            return SaveChanges();
        }
        public ICollection<Offer> Top10Sellers()
        {
            return DbContext.Offers
                .OrderByDescending(o => o.AmmountSold)
                .ToList()
                .Take(10)
                .ToList();
        }
        public ICollection<Offer> GetByCategory(Category category)
        {
            return DbContext.Offers
                .Where(o => o.Categories.Contains(category))
                .ToList();
        }
        public ICollection<Offer> GetAll()
        {
            return DbContext.Offers
                .ToList();
        }
        public ICollection<Offer> GetAvailableServices()
        {
            return DbContext.Offers
                .Where(o => o.SaleType==SaleType.Service && DateTime.Now.Hour > o.Employee.StartOfShift.Hour && DateTime.Now.Hour < o.Employee.StartOfShift.Hour && o.Availability)
                .ToList();
        }
        public ICollection<Offer> GetAvailableSubscriptions()
        {
            return DbContext.Offers
                .Where(o => o.SaleType == SaleType.Subscription && o.Availability)
                .ToList();
        }
        public Offer FindOfferById(int offerId)
        {
            return DbContext.Offers.Find(offerId);
        }
        public int SalesByCategory(Category category)
        {

            var sales = 0;
            var offers = DbContext.Offers
                .Where(o => o.Categories.Contains(category))
                .ToList();
            foreach (var offer in offers)
            {
                sales += offer.AmmountSold;
            }
            return sales;
        }
        public ICollection<Offer> LessThanInventory(int n)
        {
            return DbContext.Offers
                .Where(o => o.AmmountLeft < n)
                .ToList();
        }

        public ICollection<Offer> MoreThanInventory(int n)
        {
            return DbContext.Offers
                .Where(o => o.AmmountLeft > n)
                .ToList();
        }
    }
}
