using BusinessLayer.DTOs;
using BusinessLayer.Services;
using BusinessLayer.Services.AccountService;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    [Authorize(Roles =("ADMIN"))]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetAccount([FromRoute] int id)
        {
            return await _accountService.GetAccountById(id);
        }
        [HttpGet("")]
        public async Task<ObjectResult> GetAccounts([FromQuery][Required] String fullName,[FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return await _accountService.GetAccountByFullName(fullName, getPage(pageSize, pageNumber));
        }
        [HttpPost]
        public async Task<ObjectResult> CreateAccount([FromBody] AccountCreateRequest request)
        {
            return await _accountService.CreateAccount(request);
        }
        [HttpPut("{id}")]
        public async Task<ObjectResult> UpdateAccount([FromRoute] int id, [FromBody] AccountUpdateRequest request)
        {
            return await _accountService.UpdateAccount(id, request);
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> DeleteAccount([FromRoute] int id)
        {
            return await _accountService.DeleteAccount(id);
        }

        [HttpPost("address")]
        public async Task<ObjectResult> CreateAddress([FromBody]AddressCreateUpdateRequest request)
        {
            return await _accountService.CreateAddress(request);
        }
        [HttpPut("address/{id}")]
        public async Task<ObjectResult> UpdateAddress([FromRoute]int id ,[FromBody]AddressCreateUpdateRequest updateRequest)
        {
            return await _accountService.UpdateAddress(id, updateRequest);
        }
        [HttpDelete("address")]
        public async Task<ObjectResult> DeleteAddress([FromRoute]int id)
        {
            return await _accountService.DeleteAddress(id);
        }

        private Paging getPage(int pageSize, int pageNumber)
        {
            if (pageSize == 0 || pageNumber == 0)
            {
                return Constant.PAGE_SINGLE_ITEM;
            }
            return new Paging()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };           
        }
    }
}
