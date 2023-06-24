using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.UnitOfWork;
using System.Linq.Expressions;
using DataLayer.Models;
using AutoMapper;
using BusinessLayer.Exceptions;
using BusinessLayer.DTOs;
using DataLayer;

namespace BusinessLayer.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        private async Task<Account> getAccountById(int id)
        {
            var expressions = new List<Expression<Func<Account, bool>>>()
            {
                x => x.AccountId == id,
            };
            var account = (await _unitOfWork.AccountRepository.GetAccountsWithAddresses(expressions, Constant.PAGE_SINGLE_ITEM)).FirstOrDefault();
            if (account == null)
            {
                throw new IdNotFoundException($"Account Id: {id} not found!");
            }
            return account;
        }
        public async Task<ObjectResult> GetAccountById(int id)
        {
            var account = await getAccountById(id);
            var accountResponse = _mapper.Map<AccountResponse>(account);
            return new ObjectResult(accountResponse);
        }

        public async Task<ObjectResult> GetAccountByFullName(string fullName, Paging page)
        {
            var expressions = new List<Expression<Func<Account, bool>>>()
            {
                x => x.FullName.ToLower().Contains(fullName.ToLower()),
            };
            var accounts = await _unitOfWork.AccountRepository.GetAccountsWithAddresses(expressions, page);
            var accountResponses = accounts.Select(x => _mapper.Map<AccountResponse>(x));
            return new ObjectResult(accountResponses);
        }

        public async Task<ObjectResult> CreateAccount(AccountCreateRequest request)
        {
            Account account = _mapper.Map<Account>(request);
            _unitOfWork.AccountRepository.Create(account);
            await _unitOfWork.Save();
            return new ObjectResult(account.AccountId);
        }

        public async Task<ObjectResult> UpdateAccount(int id, AccountUpdateRequest request)
        {

            var account = await getAccountById(id);
           _mapper.Map(request,account);
            account.AccountId = id;
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.Save();
            return new ObjectResult("Updated");
        }

        public async Task<ObjectResult> DeleteAccount(int id)
        {
            var expressions = new List<Expression<Func<Account, bool>>>();
            expressions.Add(x => x.AccountId == id);
            Account account = (await _unitOfWork.AccountRepository.GetAccounts(expressions, Constant.PAGE_SINGLE_ITEM)).FirstOrDefault();
            _unitOfWork.AccountRepository.Delete(account);
            await _unitOfWork.Save();   
            return new ObjectResult("Deleted");
        }

        public async Task<ObjectResult> CreateAddress(AddressCreateUpdateRequest request)
        {
            Address address = _mapper.Map<Address>(request);
            _unitOfWork.AddressRepository.Create(address);
            await _unitOfWork.Save();
            return new ObjectResult(address);
        }

        public async Task<ObjectResult> UpdateAddress(int id, AddressCreateUpdateRequest request)
        {
            Address address = _mapper.Map<Address>(request);
            address.AddressId = id;
            _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.Save();
            return new ObjectResult("Updated");
        }

        public async Task<ObjectResult> DeleteAddress(int id)
        {
            var expressions = new List<Expression<Func<Address, bool>>>();
            expressions.Add(x => x.AddressId == id);
            var address = (await _unitOfWork.AddressRepository.GetAddress(expressions, Constant.PAGE_SINGLE_ITEM)).FirstOrDefault();
            _unitOfWork.AddressRepository.Delete(address);
            await _unitOfWork.Save();
            return new ObjectResult("Deleted");
        }

    }
}