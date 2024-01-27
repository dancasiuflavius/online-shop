using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;

namespace online_shop.Orders.Service
{
    public interface IOrderQuerryService
    {
        bool FindOrder(Order order);
        bool FindOrderByID(String orderId);
        string NextID();
        bool CancelOrder(Customer customer, String orderID);
        void ReadOrder();
        void ShowOrders();
    }
}
