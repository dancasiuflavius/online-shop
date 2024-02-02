using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Orders.Exceptions
{
    public class OrderInvalidException : Exception
    {
        public OrderInvalidException(string message) : base(message)
        {

        }
    }
}
