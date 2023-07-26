using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class OrderCreateRequest
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public int Unit { get; set; }
        public string? Note { get; set; }
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

    public class OrderStatisticResponse
    {
        public int SumProducts { get; set; }
        public List<OrderResponse> Orders { get; set; }
    }
}
