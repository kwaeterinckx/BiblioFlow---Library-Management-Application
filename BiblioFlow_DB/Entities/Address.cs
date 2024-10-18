using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string? Complement { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
