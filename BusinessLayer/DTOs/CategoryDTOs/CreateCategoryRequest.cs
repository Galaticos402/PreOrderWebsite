using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    
    public class CategoryCreateRequest
    {
        [Required(ErrorMessage = "Name is Required")]

        public string Name { get; set; } = null!;
    }
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
