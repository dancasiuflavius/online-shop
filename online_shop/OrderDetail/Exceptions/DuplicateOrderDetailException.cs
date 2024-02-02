using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.OrderDetail.Exceptions
{
    public class DuplicateOrderDetailException : Exception
    {
        public DuplicateOrderDetailException(string message) : base(message) { }
    }
}
