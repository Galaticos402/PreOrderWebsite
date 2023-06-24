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
    public class AccountRepository : RepositoryBase<Account>
    {
        public AccountRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<List<Account>> GetAccounts(List<Expression<Func<Account, bool>>> predicates, Paging page)
        {
            var query = attachPredicates(predicates);

            return await paging(query,page)
                .Include(x => x.Role)
                .ToListAsync();
        }
        public async Task<List<Account>> GetAccountsWithAddresses(List<Expression<Func<Account, bool>>> predicates, Paging page)
        {
            var query = attachPredicates(predicates);
            return await paging(query, page)
                .Include(x => x.Role)
                .Include(x => x.Addresses)  
                .ToListAsync();
        }

        public bool IsUsernameDuplicated(String username)
        {
            return _context.Accounts.Any(x => x.UserName == username);
        }
    }

}
