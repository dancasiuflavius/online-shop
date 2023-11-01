using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;

namespace online_shop.Services
{
    public class ServiceOrders
    {
        private List<Order> _ordersList;

        private String _filePath;

        public ServiceOrders()
        {
            _ordersList = new List<Order>();
            _filePath = GetDirectory();

            this.ReadOrder();
        }
        public ServiceOrders(List<Order> orders)
        {
            _ordersList = orders;

        }
        public string GetDirectory()
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
        public bool FindCustomerByID(Order order)
        {
            for (int i = 0; i < _ordersList.Count(); i++)
            {
                if (order.GetOrderID().Equals(_ordersList[i].GetOrderID()))
                    return true;
            }
            return false;
        }
        public bool AddOrder(Order order)
        {
            if (FindCustomerByID(order) == true)
                return false;
            else
                _ordersList.Add(order);
            return true;
        }
        public bool RemoveOrder(String id)
        {
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (_ordersList[i].GetOrderID().Equals(id))
                {
                    _ordersList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateOrder(String id, String customerID, int ammount, String OrderStatus, String newId)
        {
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (_ordersList[i].GetOrderID().Equals(id))
                {
                    _ordersList[i].SetCustomerID(customerID);
                    _ordersList[i].SetAmmount(ammount);
                    _ordersList[i].SetOrderStatus(OrderStatus);
                    _ordersList[i].SetOrderID(newId);
                    return true;
                }
            }
            return false;
        }
    }
}
