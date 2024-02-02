using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Exceptions
{
    public class ProductNotFoundExceptions : Exception
    {
        public ProductNotFoundExceptions(string message) : base(message)
        {
        }
    }
}
