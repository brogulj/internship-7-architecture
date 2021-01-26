using System.Collections.Generic;
#nullable enable

namespace EFCore.Data.Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public ICollection<Bill>? Bills { get; set; }
    }
}
