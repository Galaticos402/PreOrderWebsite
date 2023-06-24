using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class OrderCreateRequest
    {
        public int ProductId { get; set; }
        public int Unit { get; set; }
        public string? Note { get; set; }
        public int? AccountId { get; set; }
    }
    public class OrderResponse
    {
        public int AccountOrderId { get; set; }
        public int ProductId { get; set; }
        public int Unit { get; set; }
        public string? Note { get; set; }
        public int? AccountId { get; set; }
        public String Status { get; set; }
        public string CustomerFullName { get; set; }
    }
}
