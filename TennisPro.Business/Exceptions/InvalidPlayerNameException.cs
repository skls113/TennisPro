using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPro.Business.Exceptions
{
    public class InvalidPlayerNameException : Exception
    {
        public InvalidPlayerNameException(string message)
            :base(message)
        {
        }
    }
}
