using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;


namespace online_shop.OrderDetail
{
    public class ServiceOrderDetails
    {
        private List<OrderDetails> _ordersDetailsList;

        private string _filePath;

        public ServiceOrderDetails()
        {
            _ordersDetailsList = new List<OrderDetails>();
            _filePath = GetDirectory();

            ReadOrderDetails();
        }
        public ServiceOrderDetails(List<OrderDetails> orderDetails)
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
        public string toSave()
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
        public string NextID()
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
            List<OrderDetails> ordersD = new List<OrderDetails>();
            for (int i = 0; i < _ordersDetailsList.Count; i++)
            {
                if (orderId.Equals(_ordersDetailsList[i].GetOrderID()))
                    ordersD.Add(_ordersDetailsList[i]);
            }
            return ordersD;
        }
        public void ShowOrderDetails2(string id)
        {
            for (int i = 0; i < _ordersDetailsList.Count; i++)
                if (_ordersDetailsList[i].GetID().Equals(id))
                    Console.WriteLine(_ordersDetailsList[i].GetOrderDetails());

        }

        public void DeleteOrderDetailsByOrderID(string orderId)
        {

            for (int i = 0; i < _ordersDetailsList.Count; i++)
            {
                if (orderId.Equals(_ordersDetailsList[i].GetID()))
                {

                    _ordersDetailsList.RemoveAt(i);
                }

            }


        }

    }
}
