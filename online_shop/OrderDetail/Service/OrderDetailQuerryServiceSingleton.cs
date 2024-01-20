using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.OrderDetail.Service
{
    public class OrderDetailQuerryServiceSingleton
    {
        private static readonly IOrderDetailsQuerryService _instance = new OrderDetailsQuerryService();

        public static IOrderDetailsQuerryService Instance => _instance;

        private OrderDetailQuerryServiceSingleton() { }
    }
}
