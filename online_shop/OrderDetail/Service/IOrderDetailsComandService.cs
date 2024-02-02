using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.DTO;
using online_shop.OrderDetail;

namespace online_shop.OrderDetail
{
    public interface IOrderDetailsComandService
    {
        void AddOrderDetails(OrderDetails orderDetails);
        void RemoveOrderDetails(string id);
        void UpdateOrderDetails(string id, string order_Id, string product_id, int price, int qty, string newId);
        void SaveOrderDetails();
    }
}
