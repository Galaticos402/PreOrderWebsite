using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Detail { get; set; } = null!;
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
