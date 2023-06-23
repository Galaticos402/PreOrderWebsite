using BusinessLayer.DTOs;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.AccountService
{
    public interface IAccountService
    {
        Task<ObjectResult> GetAccountById(int id);
        Task<ObjectResult> GetAccountByFullName(string fullName, Paging page);
        Task<ObjectResult> CreateAccount(AccountCreateRequest request);
        Task<ObjectResult> UpdateAccount(int id, AccountUpdateRequest request);
        Task<ObjectResult> DeleteAccount(int id);
        Task<ObjectResult> CreateAddress(AddressCreateUpdateRequest request);
        Task<ObjectResult> UpdateAddress(int id, AddressCreateUpdateRequest request);
        Task<ObjectResult> DeleteAddress(int id);
    }
}
