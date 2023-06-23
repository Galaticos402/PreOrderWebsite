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
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetProducts(List<Expression<Func<Product, bool>>> predicates, Paging page)
        {
            var query = attachPredicates(predicates);

            return await paging(query,page)
                .Include(x=> x.Category)
                .Include(x=> x.Supply)
                .ToListAsync();
        }
    }
}
