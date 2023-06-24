using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class SupplierCreateRequest
    {
        public string Topic { get; set; } = null!;
    }
    public class SupplierResponse
    {
        public int SupplyId { get; set; }
        public string Topic { get; set; } = null!;
    }
}
