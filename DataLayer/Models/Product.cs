using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            AccountOrders = new HashSet<AccountOrder>();
            ProductCampaigns = new HashSet<ProductCampaign>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplyId { get; set; }
        public string Status { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Supply Supply { get; set; } = null!;
        public virtual ICollection<AccountOrder> AccountOrders { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaigns { get; set; }
    }
}
