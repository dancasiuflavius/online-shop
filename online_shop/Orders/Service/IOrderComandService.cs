using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Orders.Service
{
    public interface IOrderComandService
    {
        bool AddOrder(Order order);
        bool RemoveOrder(String id);
        bool UpdateOrder(String id, int customerID, int ammount, String OrderStatus, String newId);
        void SaveOrder();
    }
}
