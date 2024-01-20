using online_shop.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Orders.Service
{
    public class OrderQuerryServiceSingleton
    {
        private static readonly IOrderQuerryService _instance = new OrderQuerryService();

        public static IOrderQuerryService Instance => _instance;

        private OrderQuerryServiceSingleton() { }
    }
}
