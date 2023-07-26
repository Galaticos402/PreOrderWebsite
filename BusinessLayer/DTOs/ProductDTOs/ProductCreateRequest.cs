using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "ProductName is Required")]
        [MaxLength(255, ErrorMessage ="Max length is 255")]
        [MinLength(1,ErrorMessage ="Min length is 1")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is Required")]
        [Range(minimum: 1, maximum: 100000, ErrorMessage = "Quantity must be in range(1,100000)")]
        public int Quantity { get; set; }

        [Range(minimum: 1, maximum: 1000000000, ErrorMessage = "Price must be in range (1,1000000000)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CategoryId is Required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "SupplyId is Required")]
        public int SupplyId { get; set; }
    }
    public class ProductUpdateRequest
    {
        [Required(ErrorMessage = "ProductName is Required")]
        [MaxLength(255, ErrorMessage = "Max length is 255")]
        [MinLength(1, ErrorMessage = "Min length is 1")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is Required")]
        [Range(minimum: 1, maximum: 100000, ErrorMessage = "Quantity must be in range(1,100000)")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(minimum: 1, maximum: 1000000000, ErrorMessage = "Price must be in range (1,1000000000)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CategoryId is Required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "SupplyId is Required")]
        public int SupplyId { get; set; }
    }
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public String SupplyName { get; set; }
    }
}
