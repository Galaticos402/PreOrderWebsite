using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private readonly AccountRepository _accountRepository;  
        private readonly AddressRepository _addressRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductCampaignRepository _productCampaignRepository;  
        private readonly ProductRepository _productRepository;
        private readonly RoleRepository _roleRepository;
        private readonly SupplyRepository _supplyRepository;
        private readonly AccountOrderRepository _accountOrderRepository;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context; 
            _accountRepository = new AccountRepository(_context);
            _addressRepository = new AddressRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _productCampaignRepository = new ProductCampaignRepository(_context);
            _productRepository = new ProductRepository(_context);
            _roleRepository = new RoleRepository(_context);
            _supplyRepository = new SupplyRepository(_context);
            _accountOrderRepository = new AccountOrderRepository(_context);
        }

        public AccountRepository AccountRepository => _accountRepository;

        public AddressRepository AddressRepository => _addressRepository;

        public CategoryRepository CategoryRepository => _categoryRepository;

        public ProductCampaignRepository ProductCampaignRepository => _productCampaignRepository;

        public ProductRepository ProductRepository => _productRepository;

        public RoleRepository RoleRepository => _roleRepository;

        public SupplyRepository SupplyRepository => _supplyRepository;
        public AccountOrderRepository AccountOrderRepository => _accountOrderRepository;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
