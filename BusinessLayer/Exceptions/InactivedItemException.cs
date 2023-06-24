using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class InactivedItemException:Exception
    {
        public InactivedItemException()
        {
        }

        public InactivedItemException(string message)
            : base(message)
        {
        }

        public InactivedItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
