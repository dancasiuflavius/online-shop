using online_shop.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestOrderDetailsComandService
    {
        [Fact]
        public void testAddOrderDetailsTrue()
        {
            List<OrderDetails> odList = new List<OrderDetails>();
            //OD982,O877,P1,12000,10
            //OD976,O922,P1,12000,10
            OrderDetails od1 = new OrderDetails("OD982", "O877", "P1", 12000, 10);
            OrderDetails od2 = new OrderDetails("OD976", "O922", "P1", 12000, 10);
            odList.Add(od1);

            OrderDetailsComandService _odComandService = new OrderDetailsComandService(odList);
            _odComandService.AddOrderDetails(od2);

            Assert.True(_odComandService.FindOrderDetailsByID(od2.GetOrderID()));


        }
        public void testAddOrderDetailsFalse()
        {
            List<OrderDetails> odList = new List<OrderDetails>();
            //OD982,O877,P1,12000,10
            //OD976,O922,P1,12000,10
            OrderDetails od1 = new OrderDetails("OD982", "O877", "P1", 12000, 10);
            OrderDetails od2 = new OrderDetails("OD976", "O922", "P1", 12000, 10);
            odList.Add(od1);

            OrderDetailsComandService _odComandService = new OrderDetailsComandService(odList);
            _odComandService.AddOrderDetails(od1);

            Assert.False(_odComandService.AddOrderDetails(od1));


        }
    }
}
