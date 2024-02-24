using online_shop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Users.Exceptions;
using online_shop.Orders.Exceptions;
using online_shop.Utils;

namespace online_shop.Orders.Service
{
    public class OrderComandService : IOrderComandService
    {
        private List<Order> _ordersList;

        private String _filePath;

        private Cos _shoppingCart;

        public OrderComandService()
        {
            _ordersList = new List<Order>();
            _shoppingCart = new Cos();
            _filePath = GetDirectory();

            this.ReadOrder();
        }
        public OrderComandService(List<Order> orders)
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
        private bool FindOrder(Order order)
        {
            return _ordersList.Any(existingOrder => existingOrder.GetOrderID().Equals(order.GetOrderID()));
        }
        private bool FindOrderByID(string orderId)
        {
            return _ordersList.Any(order => orderId.Equals(order.GetOrderID()));
        }

        public void AddOrder(Order order)
        {
            if (_ordersList.Any(existingOrder => existingOrder.GetOrderID() == order.GetOrderID()))
            {
                throw new OrderInvalidException(Constants.OrderInvalidMessage);
            }
            else
            {
                _ordersList.Add(order);
            }
        }


        public void RemoveOrder(string id)
        {
            var orderToRemove = _ordersList.FirstOrDefault(order => order.GetOrderID().Equals(id));

            if (orderToRemove != null)
            {
                _ordersList.Remove(orderToRemove);
            }
            else
            {
                throw new OrderNotFoundException(Constants.OrderNotFoundMessage);
            }
        }

        public void UpdateOrder(string id, int customerID, int amount, string orderStatus, string newId)
        {
            var orderToUpdate = _ordersList.FirstOrDefault(order => order.GetOrderID().Equals(id));

            if (orderToUpdate != null)
            {
                orderToUpdate.SetCustomerID(customerID);
                orderToUpdate.SetAmmount(amount);
                orderToUpdate.SetOrderStatus(orderStatus);
                orderToUpdate.SetOrderID(newId);
                Console.WriteLine("Order updated successfully.");
            }
            else
            {
                throw new OrderNotFoundException(Constants.OrderNotFoundMessage);
            }
        }

        public String toSave()
        {

            String text = "";
            int i = 0;
            for (i = 0; i < _ordersList.Count - 1; i++)
            {

                text += _ordersList[i].ToSave() + "\n";
            }

            text += _ordersList[i].ToSave();

            return text;
        }

        public void SaveOrder()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamWriter reader = new StreamWriter(filePath))
                {
                    // Read and process the file line by line

                    reader.Write(toSave());

                    reader.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
    }
}
