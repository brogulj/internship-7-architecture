using EFCore.Data.Entities;
using EFCore.Data.Entities.Models;
using EFCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(Customer customer)
        {
            DbContext.Customers.Add(customer);
            return SaveChanges();
        }

        public ResponseResultType Edit(Customer customer, int customerId)
        {
            var customerDb = DbContext.Customers.Find(customerId);
            if(customerDb == null)
            {
                return ResponseResultType.NotFound;
            }

            customerDb.OIB = customer.OIB;
            customerDb.FirstName = customer.FirstName;
            customerDb.LastName = customer.LastName;

            return SaveChanges();
        }
        
        public ResponseResultType Delete(int customerId)
        {
            var customer = DbContext.Customers.Find(customerId);
            if (customer == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Customers.Remove(customer);

            return SaveChanges();
        }

        public ICollection<Customer> GetAll()
        {
            return DbContext.Customers.ToList();
        }
    }
}
