using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IProductService
    {
        Task<ObjectResult> CreateProduct(ProductCreateRequest request);
        Task<ObjectResult> UpdateProduct(int id, ProductUpdateRequest request);
        Task<ObjectResult> DeleteProduct(int id);
        Task<ObjectResult> SearchAndFilter(string? productName, int? categoryId, int? supplierId, int pageSize, int pageNumber);
        Task<ObjectResult> FindProductById(int id);
        Task<ObjectResult> CreateCategory(CategoryCreateRequest request);
        Task<ObjectResult> UpdateCategory(int id, CategoryCreateRequest request);
        Task<ObjectResult> DeleteCategory(int id);
        Task<ObjectResult> GetCategories(int pageNumber, int pageSize);
        Task<ObjectResult> CreateSupplier(SupplierCreateRequest request);
        Task<ObjectResult> GetSuppliers();
    }
}
