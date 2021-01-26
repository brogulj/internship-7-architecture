using EFCore.Data.Enums;
using System;
using System.Collections.Generic;

namespace EFCore.Data.Entities.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public bool Validity { get; set; }
        public DateTime DateOfSale { get; set; }
        public SaleType SaleType { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
