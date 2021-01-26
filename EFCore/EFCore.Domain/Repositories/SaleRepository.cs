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
    public class SaleRepository : BaseRepository
    {
        public SaleRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
        
        public ResponseResultType Add(Sale sale)
        {
            DbContext.Sales.Add(sale);
            return SaveChanges();
        }
        public ResponseResultType ToggleValidity(int saleId, bool validity)
        {
            var sale = DbContext.Sales.Find(saleId);
            sale.Validity = validity;
            return SaveChanges();
        }
        public int ProfitByYear(int year)
        {
            var profit = 0;
            foreach (var sale in DbContext.Sales)
            {
                if (sale.SaleDate.Year == year && sale.Validity)
                {
                    profit += sale.Offer.Price * sale.Ammount;
                }
            }
            return profit;
        }
        public ICollection<Sale> GetActiveSubscriptions()
        {
            return DbContext.Sales
                .Where(o => o.Validity && o.SaleType == SaleType.Subscription && o.SaleDate < DateTime.Now && o.SaleDate.AddMonths(o.Ammount) > DateTime.Now)
                .ToList();
        }
        public ICollection<Sale> GetSaleByType(SaleType type)
        {
            return DbContext.Sales
                .Where(s => s.SaleType == type)
                .ToList();
        }
        public ICollection<Sale> GetActiveServices()
        {
            return DbContext.Sales
                .Where(s => s.Validity && s.SaleType == SaleType.Service && s.EndTime > DateTime.Now && s.StartTime < DateTime.Now)
                .ToList();
        }
    }
}
