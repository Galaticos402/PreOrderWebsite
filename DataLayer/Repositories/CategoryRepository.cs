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
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
        }
        public async Task<List<Category>> GetCategories(Paging page)
        {
            List<Expression<Func<Category, bool>>> predicates = new List<Expression<Func<Category, bool>>>();
            predicates.Add(x => true);
            var query = attachPredicates(predicates);
            return await paging(query, page)
                .ToListAsync();
        }

    }
}
