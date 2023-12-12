using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.DTO;
using online_shop.Models;
using online_shop.DTO;

namespace online_shop.Services
{
    public class ServiceOrders
    {
        private List<Order> _ordersList;

        private String _filePath;

        private Cos _shoppingCart;

        public ServiceOrders()
        {
            _ordersList = new List<Order>();
            _shoppingCart = new Cos();
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
        public bool AddOrder(Order order)
        {
            if (FindOrder(order) == true)
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
        public bool UpdateOrder(String id, int customerID, int ammount, String OrderStatus, String newId)
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
        //public Order CreateOrder(Customer customer, OrderDetails orderDetails)
        //{
        //    Order order = new Order();
        //    order.SetOrderID(orderDetails.GetOrderID());
        //    order.SetCustomerID(customer.GetID());
        //    order.SetAmmount(orderDetails.GetPrice();



        //}
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
        public string NextID()
        {
            Random rand = new Random();
            String  id = "O" + rand.Next(1, 999);

            while (FindOrderByID(id)==true)
            {
                id = "O" + rand.Next(1, 999);
            }
            return id;
        }
        public bool CancelOrder(Customer customer, String orderID)
        {
            for(int i=0;i<_ordersList.Count;i++)
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
