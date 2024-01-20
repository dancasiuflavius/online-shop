using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace online_shop.OrderDetail
{
    public class OrderDetailsComandService : IOrderDetailsComandService
    {
        private readonly List<OrderDetails> _ordersDetailsList;

        private string _filePath;

        public OrderDetailsComandService()
        {
            _ordersDetailsList = new List<OrderDetails>();
            _filePath = GetDirectory();

            ReadOrderDetails();
        }
        public OrderDetailsComandService(List<OrderDetails> orderDetails)
        {
            _ordersDetailsList = orderDetails;

        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "order-details.txt");

            return filePath;
        }
        public void ReadOrderDetails()
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
                        _ordersDetailsList.Add(new OrderDetails(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowOrderDetails()
        {
            for (int i = 0; i < _ordersDetailsList.Count; i++)
                Console.WriteLine(_ordersDetailsList[i].GetOrderDetails());
        }
        public bool FindOrderDetails(OrderDetails order)
        {
            for (int i = 0; i < _ordersDetailsList.Count(); i++)
            {
                if (order.GetOrderID().Equals(_ordersDetailsList[i].GetOrderID()))
                    return true;
            }
            return false;
        }
        public bool FindOrderDetailsByID(string orderID)
        {
            for (int i = 0; i < _ordersDetailsList.Count(); i++)
            {
                if (orderID.Equals(_ordersDetailsList[i].GetOrderID()))
                    return true;
            }
            return false;
        }
        public bool AddOrderDetails(OrderDetails orderDetails)
        {
            if (FindOrderDetails(orderDetails) == true)
                return false;
            else
                _ordersDetailsList.Add(orderDetails);
            return true;
        }
        public bool RemoveOrderDetails(string id)
        {
            for (int i = 0; i < _ordersDetailsList.Count; i++)
            {
                if (_ordersDetailsList[i].GetOrderID().Equals(id))
                {
                    _ordersDetailsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateOrderDetails(string id, string order_Id, string product_id, int price, int qty, string newId)
        {
            for (int i = 0; i < _ordersDetailsList.Count; i++)
            {
                if (_ordersDetailsList[i].GetOrderID().Equals(id))
                {
                    _ordersDetailsList[i].SetOrderID(order_Id);
                    _ordersDetailsList[i].SetProductID(product_id);
                    _ordersDetailsList[i].SetPrice(price);
                    _ordersDetailsList[i].SetPrice(qty);
                    _ordersDetailsList[i].SetOrderID(newId);
                    return true;
                }
            }
            return false;
        }
        private string toSave()
        {

            string text = "";
            int i = 0;
            for (i = 0; i < _ordersDetailsList.Count - 1; i++)
            {

                text += _ordersDetailsList[i].ToSave() + "\n";
            }

            text += _ordersDetailsList[i].ToSave();

            return text;
        }

        public void SaveOrderDetails()
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
