using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.Repositories
{
    public class RoleRepository : RepositoryBase<Address>
    {
        public RoleRepository(DatabaseContext context) : base(context)
        {
             
        }
    }
}
