using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public class ProductCampaignRepository : RepositoryBase<ProductCampaign>
    {
        public ProductCampaignRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<List<ProductCampaign>> GetCampaigns(List<Expression<Func<ProductCampaign, bool>>> predicates, Paging page)
        {
            var query = attachPredicates(predicates);
            return await paging(query, page)
                .Include(x=> x.Product)
                .Include(x=> x.DepositAmount)
                .ToListAsync();
        }
        public async Task<ProductCampaign> GetCampaignByid(int id)
        {
            return await _context.ProductCampaigns
                .Include(x=> x.Product)
                .Include(x=> x.DepositAmount)
                .FirstOrDefaultAsync(x => x.ProductCampaignId == id);
        }
    }
}
