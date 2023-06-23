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
        
    }
}
