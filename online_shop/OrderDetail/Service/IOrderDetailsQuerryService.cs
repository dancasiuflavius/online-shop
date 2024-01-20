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
        string NextID();
    }
}
