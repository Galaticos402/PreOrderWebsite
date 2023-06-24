using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Exceptions;
using DataLayer;
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
    public class ProductService : BaseService, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<ObjectResult> CreateProduct(ProductCreateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.Status = "ACTIVE";
            _unitOfWork.ProductRepository.Create(product);
            await _unitOfWork.Save();
            return new ObjectResult(product.ProductId);
        }
        private async Task<Product> GetProductById(int id) 
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(id);
            if (product == null)
            {
                throw new IdNotFoundException($"Product Id: {id} not found");
            }
            if (product.Status == "SUSPENDED")
            {
                throw new InactivedItemException($"Product Id: {id} is suspended");
            }
            return product;
        }

        public async Task<ObjectResult> UpdateProduct(int id, ProductUpdateRequest request)
        {
            var product = await GetProductById(id);
            _mapper.Map(request, product);
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
            return new ObjectResult("Updated");
        }

        public async Task<ObjectResult> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            product.Status = "SUSPENDED";
            await _unitOfWork.Save();
            return new ObjectResult("DELETED");
        }
        
        public async Task<ObjectResult> SearchAndFilter(String? productName,int? categoryId, int? supplierId, int pageSize,int pageNumber)
        {
            var expressions = new List<Expression<Func<Product, bool>>>();
            expressions.Add(x => x.Status == "ACTIVE");
            if (productName != null)
            {
                expressions.Add(x => x.ProductName.ToLower().Contains(productName.ToLower()));
            }
            if(categoryId != null)
            {
                expressions.Add(x => x.CategoryId == categoryId);
            }
            if (supplierId != null)
            {
                expressions.Add(x => x.SupplyId == supplierId); 
            }
            
            var page = toPage(pageSize, pageNumber);
            var products = await _unitOfWork.ProductRepository.GetProducts(expressions, page);
            var res = products.Select(x=> _mapper.Map<ProductResponse>(x)).ToList();
            return new ObjectResult(res);
        }
        public async Task<ObjectResult> FindProductById(int id)
        {
            var product = await GetProductById(id);
            var res = _mapper.Map<ProductResponse>(product);
            return new ObjectResult(res);
        }

        public async Task<ObjectResult> CreateCategory(CategoryCreateRequest request)
        {
            Category category = new Category()
            {
                Name = request.Name,
            };
            _unitOfWork.CategoryRepository.Create(category);
            await _unitOfWork.Save();
            return new ObjectResult(category.CategoryId);
        }
        private async Task<Category> GetCategoryById(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryById(id);
            if (category == null)
            {
                throw new IdNotFoundException($"Category Id: {id} not found!");
            }
            return category;
        }
        public async Task<ObjectResult> UpdateCategory(int id, CategoryCreateRequest request)
        {
            var category = await GetCategoryById(id);
            category.Name = request.Name;
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.Save();
            return new ObjectResult("Updated");
        }
        public async Task<ObjectResult> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.Save();
            return new ObjectResult("Deleted");
        }

        public async Task<ObjectResult> GetCategories(int pageNumber, int pageSize)
        {
            var page = toPage(pageNumber, pageSize);
            var categories = await _unitOfWork.CategoryRepository.GetCategories(page);
            var res = categories.Select(x => _mapper.Map<CategoryResponse>(x));
            return new ObjectResult(res);
        }

        public async Task<ObjectResult> CreateSupplier(SupplierCreateRequest request)
        {
            var supp = _mapper.Map<Supply>(request);
            supp.Status = "ACTIVE";
            _unitOfWork.SupplyRepository.Create(supp);
            await _unitOfWork.Save();
            return new ObjectResult(supp.SupplyId);
        }
        
        public async Task<ObjectResult> GetSuppliers()
        {
            var suppliers = await _unitOfWork.SupplyRepository.GetSupplies();
            var res = suppliers.Select(x => _mapper.Map<SupplierResponse>(x));
            return new ObjectResult(res);
        }
    }
}
