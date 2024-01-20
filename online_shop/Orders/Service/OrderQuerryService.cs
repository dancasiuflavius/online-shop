using online_shop.DTO;
using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Orders.Service
{
    public class OrderQuerryService : IOrderQuerryService
    {
        private List<Order> _ordersList;

        private String _filePath;

        private Cos _shoppingCart;

        public OrderQuerryService()
        {
            _ordersList = new List<Order>();
            _shoppingCart = new Cos();
                       
        }
        public OrderQuerryService(List<Order> orders)
        {
            _ordersList = orders;

        }
        public bool FindOrder(Order order)
        {
            for (int i = 0; i < _ordersList.Count(); i++)
            {
                if (order.GetOrderID().Equals(_ordersList[i].GetOrderID()))
                    return true;
            }
            return false;
        }
        public bool FindOrderByID(String orderId)
        {
            for (int i = 0; i < _ordersList.Count(); i++)
            {
                if (orderId.Equals(_ordersList[i].GetOrderID()))
                    return true;
            }
            return false;
        }
        public string NextID()
        {
            Random rand = new Random();
            String id = "O" + rand.Next(1, 999);

            while (FindOrderByID(id) == true)
            {
                id = "O" + rand.Next(1, 999);
            }
            return id;
        }
    }
}
