using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data.Entities
{
    interface IOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AmmountLeft { get; set; }
        public int AmmountSold { get; set; }
        public int Availabilty { get; set; }
    }
}
