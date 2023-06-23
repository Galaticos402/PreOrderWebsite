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
    public class AddressRepository : RepositoryBase<Address>
    {
        public AddressRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Address>> GetAddress(List<Expression<Func<Address, bool>>> predicates, Paging page)
        {
            var query = attachPredicates(predicates);
            return await paging(query, page)
                .Include(x=> x.Account)
                .ToListAsync();         
        }
    }
}
