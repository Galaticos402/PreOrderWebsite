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

            //Product
            CreateMap<Product, ProductResponse>()
                .ForMember(des => des.CategoryName, act => act.MapFrom(src => src.Category.Name))
                .ForMember(des => des.SupplyName, act => act.MapFrom(src => src.Supply.Topic));
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();

            //Category
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryCreateRequest, Category>();
            //Supplier
            CreateMap<Supply, SupplierResponse>();
            CreateMap<SupplierCreateRequest, Supply>();

            //Order
            CreateMap<OrderCreateRequest, AccountOrder>();
            CreateMap<AccountOrder, OrderResponse>()
                .ForMember(des => des.CustomerFullName, act => act.MapFrom(src => src.Account.FullName));

            //ProductCampaign
            CreateMap<ProductCampaign, ProductCampaignResponse>()
                .ForMember(des => des.ProductName, act=> act.MapFrom(src => src.Product.ProductName))
                .ForMember(des => des.DepositAmount, act => act.MapFrom(src => src.DepositAmount.Amount));
            CreateMap<ProductCampaignCreateRequest, ProductCampaign>();
            CreateMap<ProductCampaignUpdateRequest, ProductCampaign>();

        }
    }
}
