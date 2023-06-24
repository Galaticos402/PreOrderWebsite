using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class ProductCampaignResponse
    {
        public int ProductCampaignId { get; set; }
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
        public int DepositAmount { get; set; }
        public string Address { get; set; } = null!;
        public string? Remark { get; set; }
        public string Status { get; set; } = null!;
    }
    public class ProductCampaignCreateRequest
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
        public int DepositAmountId { get; set; }
        public string Address { get; set; } = null!;
        public string? Remark { get; set; }
    }

    public class ProductCampaignUpdateRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
        public int DepositAmountId { get; set; }
        public string Address { get; set; } = null!;
        public string? Remark { get; set; }
    }
}
