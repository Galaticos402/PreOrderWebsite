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
   public class RepositoryBase<T> : IRepositoryBase<T>  where T : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;
        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
      
        public  void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        public void  Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void  Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
        }
        protected IQueryable<T> paging(IQueryable<T> query, Paging page)
        {
            return query.Skip(page.PageSize * (page.PageNumber - 1))
                .Take(page.PageSize);
        }

        protected IQueryable<T> attachPredicates(List<Expression<Func<T, bool>>> predicates)
        {
            var query = _dbSet.Where(predicates[0]);
            for (int i = 1; i < predicates.Count; i++)
            {
                query = query.Where(predicates[i]);
            }
            return query;
        }
    }
}
