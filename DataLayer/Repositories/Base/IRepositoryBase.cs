using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
