using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class AccountCreateRequest
    {
        [Required(ErrorMessage = "UserName is Required")]
        [MaxLength(20)]
        [MinLength(5)]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Password is Required")]
        [MaxLength(20)]
        [MinLength(5)]
        public string Password { get; set; } = null!;
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email.")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Must provide RoleId")]
        public int RoleId { get; set; }
        [MaxLength(200)]
        public string? FullName { get; set; }
    }
}
