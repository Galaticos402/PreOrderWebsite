using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest request)
        {
            var result = await _productService.CreateProduct(request);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateRequest request)
        {
            var result = await _productService.UpdateProduct(id, request);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> SearchAndFilter(string? productName, int? categoryId, int? supplierId, [Required] int pageSize, [Required] int pageNumber)
        {
            var result = await _productService.SearchAndFilter(productName, categoryId, supplierId, pageSize, pageNumber);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindProductById(int id)
        {
            var result = await _productService.FindProductById(id);
            return result;
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequest request)
        {
            return await _productService.CreateCategory(request);
        }

        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateRequest request)
        {
            return await _productService.UpdateCategory(id,request);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories([Required] int pageSize, [Required] int pageNumber)
        {
            return await _productService.GetCategories(pageSize, pageNumber);
        }
        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            return await _productService.GetSuppliers();
        }
        [HttpPost("suppliers")]
        public async Task<IActionResult> CreateSupplier(SupplierCreateRequest request)
        {
            return await _productService.CreateSupplier(request);
        }
    }
}
