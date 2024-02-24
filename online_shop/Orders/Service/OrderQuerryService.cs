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
            _filePath = GetDirectory();

            this.ReadOrder();

        }
        public OrderQuerryService(List<Order> orders)
        {
            _ordersList = orders;
            

        }
        private string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "orders.txt");

            return filePath;
        }
        public void ReadOrder()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read and process the file line by line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _ordersList.Add(new Order(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowOrders()
        {
            foreach (var order in _ordersList)
            {
                Console.WriteLine(order.GetOrderDescription());
            }
        }

        public bool FindOrder(Order order)
        {
            return _ordersList.Any(existingOrder => existingOrder.GetOrderID() == order.GetOrderID());
        }

        public bool FindOrderByID(string orderId)
        {
            return _ordersList.Any(order => order.GetOrderID() == orderId);
        }

        public string NextID() //// ????
        {
            Random rand = new Random();
            String id = "O" + rand.Next(1, 999);

            while (FindOrderByID(id) == true)
            {
                id = "O" + rand.Next(1, 999);
            }
            return id;
        }
        public bool CancelOrder(Customer customer, string orderID)/// First Or Default?
        {
            var orderToCancel = _ordersList.FirstOrDefault(order => order.GetOrderID() == orderID && order.GetCustomerID() == customer.GetID());

            if (orderToCancel != null)
            {
                orderToCancel.SetOrderStatus("Declined");
                return true;
            }

            return false;
        }
        public Order GetOrderByID(string orderID)
        {
            return _ordersList.FirstOrDefault(order => order.GetOrderID() == orderID);
        }

    }
}
