using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class DepositAmount
    {
        public DepositAmount()
        {
            ProductCampaigns = new HashSet<ProductCampaign>();
        }

        public int DepositAmount1 { get; set; }
        public string Type { get; set; } = null!;
        public double Amount { get; set; }

        public virtual ICollection<ProductCampaign> ProductCampaigns { get; set; }
    }
}
