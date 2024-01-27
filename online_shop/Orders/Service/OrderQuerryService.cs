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
            for (int i = 0; i < _ordersList.Count; i++)
                Console.WriteLine(_ordersList[i].GetOrderDescription());
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
        public bool CancelOrder(Customer customer, String orderID)
        {
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (_ordersList[i].GetOrderID().Equals(orderID) && customer.GetID().Equals(_ordersList[i].GetCustomerID()))
                {
                    _ordersList[i].SetOrderStatus("Declined");
                    return true;

                }


            }
            return false;


        }
    }
}
