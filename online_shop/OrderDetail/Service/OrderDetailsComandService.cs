using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Utils;
using online_shop.OrderDetail.Exceptions;


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
        private string GetDirectory()
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
            _ordersDetailsList.ForEach(orderDetail => Console.WriteLine(orderDetail.GetOrderDetails()));
        }

        public bool FindOrderDetails(OrderDetails order)
        {
            return _ordersDetailsList.Any(od => od.GetOrderID() == order.GetOrderID());
        }

        public bool FindOrderDetailsByID(string orderID)
        {
            return _ordersDetailsList.Any(order => order.GetOrderID() == orderID);
        }
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            if (_ordersDetailsList.Any(order => order.GetOrderID() == orderDetails.GetOrderID()))
            {
                Console.WriteLine("Error: " + Constants.DuplicateOrderDetailMessage);
                return;
            }

            _ordersDetailsList.Add(orderDetails);
            Console.WriteLine("Order details added successfully.");
        }

        public void RemoveOrderDetails(string id)
        {
            var removed = _ordersDetailsList.RemoveAll(order => order.GetOrderID().Equals(id));

            if (removed > 0)
            {
                Console.WriteLine("Order details removed successfully.");
            }
            else
            {
                Console.WriteLine("Error: " + Constants.OrderDetailNotFoundMessage);
            }
        }

        public void UpdateOrderDetails(string id, string order_Id, string product_id, int price, int qty, string newId)
        {
            var orderDetail = _ordersDetailsList.FirstOrDefault(order => order.GetOrderID().Equals(id));

            if (orderDetail != null)
            {
                orderDetail.SetOrderID(order_Id);
                orderDetail.SetProductID(product_id);
                orderDetail.SetPrice(price);
                orderDetail.SetQuantity(qty);
                orderDetail.SetOrderID(newId);
                Console.WriteLine("Order details updated successfully.");
            }
            else
            {
                Console.WriteLine("Error: " + Constants.OrderDetailNotFoundMessage);
            }
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
