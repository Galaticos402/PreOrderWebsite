using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class PagingResult<T>
    {
        public List<T> Results { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}
