using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Orders.Service
{
    public class OrderComandServiceSingleton
    {
        private static readonly IOrderComandService _instance = new OrderComandService();

        public static IOrderComandService Instance => _instance;

        private OrderComandServiceSingleton() { }
    }
}

