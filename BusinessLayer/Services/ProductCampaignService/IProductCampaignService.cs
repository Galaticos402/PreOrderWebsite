using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IProductCampaignService
    {
        Task<ObjectResult> GetCampaignById(int id);
        Task<ObjectResult> GetCampaignByProductId(int id, int pageSize, int pageNumber);
        Task<ObjectResult> GetCampaigns(int pageSize, int pageNumber);
        Task<ObjectResult> CreateCampaign(ProductCampaignCreateRequest request);
        Task<ObjectResult> UpdateCampaign(int id, ProductCampaignUpdateRequest request);
        Task<ObjectResult> GetOrdersByProductId(int productId);
    }
}
