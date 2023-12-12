using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.DTO
{
    public class CreateOrderRequest
    {

         public List<OrderDetails> Details { get; set; }

        public Order order { get; set; } 
    }
}
