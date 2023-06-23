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
    public class SupplyRepository : RepositoryBase<Supply>
    {
        public SupplyRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Supply>> GetSupplies()
        {
            return  await _context.Supplies.ToListAsync();
        }
    }
}
