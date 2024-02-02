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
        void AddOrder(Order order);
        void RemoveOrder(String id);
        void UpdateOrder(String id, int customerID, int ammount, String OrderStatus, String newId);
        void ReadOrder();
        void SaveOrder();
    }
}
