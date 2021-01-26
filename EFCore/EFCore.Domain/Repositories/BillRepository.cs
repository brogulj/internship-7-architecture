using EFCore.Data.Entities;
using EFCore.Data.Entities.Models;
using EFCore.Data.Enums;
using EFCore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Repositories
{
    public class BillRepository : BaseRepository
    {
        public BillRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Bill bill)
        {
            DbContext.Bills.Add(bill);

            return SaveChanges();
        }

        public ResponseResultType ToggleValidity(int billId, bool validity)
        {
            var bill = DbContext.Bills.Find(billId);
            if (bill == null)
        {
            return ResponseResultType.NotFound;
        }
            bill.Validity = validity;
            return SaveChanges();
        }
        public ICollection<Bill> GetByYear(int year)
        {
            return DbContext.Bills
                .Where(b => b.DateOfSale.Year == year)
                .ToList();
        }
        public ICollection<Bill> GetBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            return DbContext.Bills
                .Where(b => b.DateOfSale > firstDate && b.DateOfSale < secondDate && b.Validity)
                .ToList();
        }
        public ICollection<Bill> GetByType(SaleType saleType)
        {
            return DbContext.Bills
                .Where(b => b.SaleType == saleType)
                .ToList();
        }
        public ICollection<Bill> GetByCategory(Category category)
        {
            var sales = DbContext.Sales.ToList();
            var bills = new List<Bill>();
            foreach (var sale in sales)
            {
                if (sale.Offer.Categories.Contains(category) && sale.Bill.Validity)
                {
                    bills.Add(sale.Bill);
                }
            }
            return bills;
        }
        public ICollection<Bill> GetAfterDate(DateTime date)
        {
            return DbContext.Bills
                .Where(b => b.DateOfSale > date)
                .ToList();
        }
        public ICollection<Bill> GetBeforeDate(DateTime date)
        {
            return DbContext.Bills
                .Where(b => b.DateOfSale < date)
                .ToList();
        }
        public int GetPrice(int billId)
        {
            var bill = DbContext.Bills
                .Find(billId);
            var price = 0;
            foreach (var sale in bill.Sales)
            {
                price += sale.Offer.Price * sale.Ammount;
            }
            return price;
        }
        public ResponseResultType AddSaleToBill(Sale sale, Bill bill)
        {
            sale.Bill = bill;
            sale.BillId = bill.Id;
            bill.Sales.Add(sale);
            return ResponseResultType.Success;
        }
        public ICollection<Bill> GetAll()
        {
            return DbContext.Bills
                .ToList();
        }
        public Bill AddNewBill(SaleType saleType)
        {
            var bill = new Bill();
            bill.SaleType = saleType;
            DbContext.Bills.Add(bill);
            SaveChanges();
            return bill;
        }
        public ResponseResultType CancelById(int billId)
        {
            var bill = DbContext.Bills.Find(billId);
            if (bill == null)
            {
                return ResponseResultType.NotFound;
            }

            bill.Validity = false;
            foreach (var sale in bill.Sales)
            {
                sale.Validity = false;
                sale.Offer.AmmountSold -= sale.Ammount;
                sale.Offer.AmmountLeft += sale.Ammount;
            }

            return ResponseResultType.Success;
        }
    }
}
