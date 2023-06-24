using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BaseService
    {
        protected Paging toPage(int pageSize, int pageNumber)
        {
            var page = new Paging()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return page;
        }
    }
}
