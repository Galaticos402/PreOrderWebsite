using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AccountOrderRepository : RepositoryBase<AccountOrder>
    {
        public AccountOrderRepository(DatabaseContext context) : base(context)
        {
        }
        
        public async Task<List<AccountOrder>> GetOrdersByAccountId(int accountId, Paging page)
        {
            var query =  _context.AccountOrders
                .Where(x => x.AccountId == accountId);
            return await paging(query, page)
                .ToListAsync();
                
        }
        public async Task<List<AccountOrder>> GetOrders(Paging page)
        {
            var query = _context.AccountOrders.Where(x => true);
            return await paging(query, page)
                .Include(x => x.Account)
                .ToListAsync();
        }

        public async Task<AccountOrder> GetOrderById(int orderId)
        {
            return await _context.AccountOrders
                .Include(x=> x.Account)
                .FirstOrDefaultAsync(x => x.AccountOrderId == orderId);
        }

    }
}
