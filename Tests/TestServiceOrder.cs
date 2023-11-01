using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Services;

namespace Tests
{
    public class TestServiceOrder
    {
        [Fact]
        public void testFindOrderByIdTrue()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);

            Assert.True(_serviceOrders.FindOrderByID(order1));
        }
        [Fact]
        public void testFindProductByIdFalse()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            Order order2 = new Order("O1B", "1B", 2, "Delivered");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);

            Assert.False(_serviceOrders.FindOrderByID(order2));
        }
        [Fact]
        public void testAddOrderTrue()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            Order order2 = new Order("O1B", "1B", 2, "Delivered");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);
            _serviceOrders.AddOrder(order2);

            Assert.True(_serviceOrders.FindOrderByID(order2));
        }
        [Fact]
        public void testAddOrderFalse()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            Order order2 = new Order("O1B", "1B", 2, "Delivered");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);
            

            Assert.False(_serviceOrders.AddOrder(order1));
        }
        [Fact]
        public void testRemoveOrderTrue()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            Order order2 = new Order("O1B", "1B", 2, "Delivered");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);
            _serviceOrders.RemoveOrder("O1A");

            Assert.False(_serviceOrders.FindOrderByID(order1));

            
        }
        [Fact]
        public void testRemoveOrderFalse() //Verific daca merge remove, false - inseamna ca nu merge, am pus Assert True ca sa stiu ca elementul  mai e in lista
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            Order order2 = new Order("O1B", "1B", 2, "Delivered");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);
            string id = "x";

            Assert.False(_serviceOrders.RemoveOrder("id"));
        }
        [Fact]
        public void testUpdateOrderTrue()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");
            
            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);

            Assert.True(_serviceOrders.UpdateOrder("O1A", "1Z", 1, "Delivered", "aX"));
        }
        [Fact]
        public void testUpdateOrderFalse()
        {
            List<Order> _ordersList = new List<Order>();

            Order order1 = new Order("O1A", "1A", 3, "Pending");

            _ordersList.Add(order1);

            ServiceOrders _serviceOrders = new ServiceOrders(_ordersList);

            Assert.False(_serviceOrders.UpdateOrder("OA1", "1Z", 1, "Delivered", "aX"));
        }
    }
}
