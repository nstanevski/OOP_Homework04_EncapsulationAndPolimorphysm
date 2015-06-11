using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    class UnathorizedTransactionException:Exception
    {
        public UnathorizedTransactionException(string message)
        : base(message)
        {
        }

    }
}
