using EFCore.Data.Enums;
using System;
#nullable enable
namespace EFCore.Data.Entities.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int Ammount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public SaleType SaleType { get; set; }
        public bool Validity { get; set; }
        public int? BillId { get; set; }
        public Bill? Bill { get; set; }
        public int? OfferId { get; set; }
        public Offer? Offer { get; set; }
    }
}
