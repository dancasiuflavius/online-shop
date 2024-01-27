using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.OrderDetail
{
    public interface IOrderDetailsQuerryService
    {
        bool FindOrderDetails(OrderDetails order);
        bool FindOrderDetailsByID(string orderID);
        void ShowOrderDetails();
        void ShowOrderDetails2(string id);
        string NextID();
        void ReadOrderDetails();
        List<OrderDetails> GetOrderDetailsByOrderID(string orderId);
    }
}
