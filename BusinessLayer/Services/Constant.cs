using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class Constant
    {
        public static Paging PAGE_SINGLE_ITEM = new Paging()
        {
            PageNumber = 1,
            PageSize = 1
        };
    }
}
