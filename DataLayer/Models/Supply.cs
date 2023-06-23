using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Supply
    {
        public Supply()
        {
            Products = new HashSet<Product>();
        }

        public int SupplyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Topic { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
