using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountOrders = new HashSet<AccountOrder>();
            Addresses = new HashSet<Address>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public string? FullName { get; set; }
        public string? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<AccountOrder> AccountOrders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
