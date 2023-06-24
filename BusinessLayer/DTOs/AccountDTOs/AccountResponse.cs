using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class AccountResponse
    {
        public int AccountId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public string? FullName { get; set; }
        public string RoleName { get;set; }
        public List<AddressResponse> AddressResponses { get; set; }
    }
}
