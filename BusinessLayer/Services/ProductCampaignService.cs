using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Exceptions;
using DataLayer.Models;
using DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductCampaignService:BaseService, IProductCampaignService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductCampaignService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        private async Task<ProductCampaign> GetCampaign(int id)
        {
            var campaign =await  _unitOfWork.ProductCampaignRepository.GetCampaignByid(id);
            if (campaign == null)
            {
                throw new IdNotFoundException($"Product Campaign with Id: {id} not found");
            }
            return campaign;
        }

        public async Task<ObjectResult> GetCampaignById(int id)
        {
            var campaign = await GetCampaign(id);
            var res = _mapper.Map<ProductCampaignResponse>(campaign);
            return new ObjectResult(res);
        }
        public async Task<ObjectResult> GetCampaignByProductId(int id, int pageSize, int pageNumber)
        {
            var expressions = new List<Expression<Func<ProductCampaign, bool>>>();
           
            expressions.Add(x => x.ProductId == id);
            var page = toPage(pageSize, pageNumber);
            var campaigns = await _unitOfWork.ProductCampaignRepository.GetCampaigns(expressions, page);
            var res = campaigns.Select(x => _mapper.Map<ProductCampaignResponse>(x));
            return new ObjectResult(res);
        }
        public async Task<ObjectResult> GetCampaigns(int pageSize, int pageNumber)
        {
            var expressions = new List<Expression<Func<ProductCampaign, bool>>>();
            expressions.Add(x => true);
            var page = toPage(pageSize, pageNumber);
            var campaigns = await _unitOfWork.ProductCampaignRepository.GetCampaigns(expressions, page);
            var res = campaigns.Select(x => _mapper.Map<ProductCampaignResponse>(x));
            return new ObjectResult(res);
        }
        private void checkDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new DateTimeException("End date is before Start date");
            }
            if (endDate.Date < DateTime.Now.Date)
            {
                throw new DateTimeException("End Date must be bigger than Current time");
            }
             
        }
        public async Task<ObjectResult> CreateCampaign(ProductCampaignCreateRequest request)
        {
            checkDate(request.StartDate, request.EndDate);
            var campaign = _mapper.Map<ProductCampaign>(request);
            campaign.Status = "PENDING";
            _unitOfWork.ProductCampaignRepository.Create(campaign);
            await _unitOfWork.Save();
            return new ObjectResult(campaign.ProductCampaignId);
        }
        public async Task<ObjectResult> UpdateCampaign(int id, ProductCampaignUpdateRequest request)
        {
            var campaign = await GetCampaign(id);
            _mapper.Map(request ,campaign);
            _unitOfWork.ProductCampaignRepository.Update(campaign);
            await _unitOfWork.Save();
            return new ObjectResult("Updated");
        }
        
    }

}
