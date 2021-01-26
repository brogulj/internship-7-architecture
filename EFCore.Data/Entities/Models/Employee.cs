using System;
using System.Collections.Generic;

namespace EFCore.Data.Entities.Models
{
    public class Employee

    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartOfShift { get; set; }
        public DateTime EndOfShift { get; set; }
        public bool Availability { get; set; }
        public ICollection<Offer> offers { get; set; }
    }
}