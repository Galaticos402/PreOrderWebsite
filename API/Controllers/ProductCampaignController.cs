using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/product-campaigns")]
    public class ProductCampaignController : ControllerBase
    {
        private readonly IProductCampaignService _productCampaignService;

        public ProductCampaignController(IProductCampaignService productCampaignService)
        {
            _productCampaignService = productCampaignService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignById(int id)
        {
            var result = await _productCampaignService.GetCampaignById(id);
            return result;
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetCampaignByProductId(int id, int pageSize, int pageNumber)
        {
            var result = await _productCampaignService.GetCampaignByProductId(id, pageSize, pageNumber);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetCampaigns(int pageSize, int pageNumber)
        {
            var result = await _productCampaignService.GetCampaigns(pageSize, pageNumber);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign(ProductCampaignCreateRequest request)
        {
            var result = await _productCampaignService.CreateCampaign(request);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCampaign(int id, ProductCampaignUpdateRequest request)
        {
            var result = await _productCampaignService.UpdateCampaign(id, request);
            return result;
        }
    }
}
