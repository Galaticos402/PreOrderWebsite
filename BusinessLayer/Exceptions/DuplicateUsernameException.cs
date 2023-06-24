using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class DuplicateUsernameException:Exception
    {
        public DuplicateUsernameException()
        {
        }

        public DuplicateUsernameException(string message)
            : base(message)
        {
          
        }

        public DuplicateUsernameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
