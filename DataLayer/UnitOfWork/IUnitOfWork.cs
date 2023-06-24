using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        AccountRepository AccountRepository { get; }
        AddressRepository AddressRepository { get; }
        CategoryRepository CategoryRepository { get; }
        ProductCampaignRepository ProductCampaignRepository { get; }
        ProductRepository ProductRepository { get; }
        RoleRepository RoleRepository { get; }
        SupplyRepository SupplyRepository { get; }
        AccountOrderRepository AccountOrderRepository { get; }
        void Dispose();
        Task Save();
    }
}
