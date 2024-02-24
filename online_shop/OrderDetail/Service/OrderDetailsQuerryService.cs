using online_shop.Products.Model;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.OrderDetail
{
    public class OrderDetailsQuerryService : IOrderDetailsQuerryService
    {
        private List<OrderDetails> _ordersDetailsList;
        private string _filePath;

        public OrderDetailsQuerryService()
        {
            _ordersDetailsList = new List<OrderDetails>();

            _filePath = GetDirectory();

            ReadOrderDetails();
        }
        public OrderDetailsQuerryService(List<OrderDetails> orderDetails)
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

        public string NextID()///???
        {
            Random rand = new Random();
            string id = "OD" + rand.Next(1, 999);

            while (FindOrderDetailsByID(id) == true)
            {
                id = "OD" + rand.Next(1, 999);
            }
            return id;

        }
        public List<OrderDetails> GetOrderDetailsByOrderID(string orderId)
        {
            return _ordersDetailsList.Where(order => orderId.Equals(order.GetOrderID())).ToList();
        }
        public void ShowOrderDetails2(string id)
        {
            var orderDetails = _ordersDetailsList.Where(order => order.GetID().Equals(id));

            foreach (var orderDetail in orderDetails)
            {
                Console.WriteLine(orderDetail.GetOrderDetails());
            }
        }
    }
}
