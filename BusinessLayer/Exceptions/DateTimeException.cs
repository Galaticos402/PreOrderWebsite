using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class DateTimeException:Exception
    {
        public DateTimeException()
        {
        }

        public DateTimeException(string message)
            : base(message)
        {

        }

        public DateTimeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
