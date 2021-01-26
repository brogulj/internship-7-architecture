using EFCore.Data.Enums;
using System.Collections.Generic;

#nullable enable

namespace EFCore.Data.Entities.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int AmmountLeft { get; set; }
        public int AmmountSold { get; set; }
        public bool Availability { get; set; }
        public SaleType SaleType { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
