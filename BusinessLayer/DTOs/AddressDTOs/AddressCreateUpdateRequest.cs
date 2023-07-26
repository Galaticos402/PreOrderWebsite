using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class AddressCreateUpdateRequest
    {
        [Required]
        [StringLength(200, ErrorMessage ="Detail is maximum 200")]
        public String Detail { get; set; } = null!;
    }
}
