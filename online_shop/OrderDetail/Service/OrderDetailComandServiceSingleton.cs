using online_shop.Products.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.OrderDetail.Service
{
    public class OrderDetailComandServiceSingleton
    {
        private static readonly IOrderDetailsComandService _instance = new OrderDetailsComandService();

        public static IOrderDetailsComandService Instance => _instance;

        private OrderDetailComandServiceSingleton() { }
    }
}
