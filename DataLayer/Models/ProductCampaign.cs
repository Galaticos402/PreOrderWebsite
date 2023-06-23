using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class ProductCampaign
    {
        public int ProductCampaignId { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
        public int DepositAmountId { get; set; }
        public string Address { get; set; } = null!;
        public string? Remark { get; set; }
        public string Status { get; set; } = null!;

        public virtual DepositAmount DepositAmount { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
