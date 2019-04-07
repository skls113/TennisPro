using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPro.Business.Exceptions
{
    public class InvalidMaxSetsToPlayException : Exception
    {
        public InvalidMaxSetsToPlayException(string message)
            :base(message)
        {
        }
    }
}
