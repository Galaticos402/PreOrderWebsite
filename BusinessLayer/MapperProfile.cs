using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using BusinessLayer.DTOs;
namespace BusinessLayer
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //Address
            CreateMap<AddressCreateUpdateRequest, Address>();
            CreateMap<Address, AddressResponse>();
            //Account
            CreateMap<AccountCreateRequest, Account>();
            CreateMap<AccountUpdateRequest, Account>();
            CreateMap<Account, AccountResponse>()
                .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName))
                .ForMember(des => des.AddressResponses, act => act.MapFrom(src => src.Addresses));

            // 
        }
    }
}
