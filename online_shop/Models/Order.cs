using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace online_shop.Models
{
    public class Order
    {
        private String _id;
        private String _customerID;
        private int _ammount;
        private String _orderStatus;

        public Order()
        {

        }
        public Order(string id, string customerID, int ammount, string orderStatus)
        {
            _id = id;
            _customerID = customerID;
            _ammount = ammount;
            _orderStatus = orderStatus;
        }
        public Order(String proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _customerID = atribute[1];
            _ammount = Int32.Parse(atribute[2]);
            _orderStatus = atribute[3];
        }
        public String GetOrderDescription()
        {
            String text = "";
            text += "ID: " + _id + "\n";
            text += "Customer ID: " + _customerID + "\n";
            text += "Ammount: " + _ammount  + "\n";
            text += "Order Status: " + _orderStatus + "\n";           
            return text;
        }

        public String GetOrderID()
        {
            return _id;
        }
        public void SetOrderID(String id)
        {
            _id = id;
        }
        public String GetCustomerID()
        {
            return _customerID;
        }
        public void SetCustomerID(String customerID)
        {
            _customerID = customerID;
        }
        public int GetAmmount()
        {
            return _ammount;
        }
        public void SetAmmount(int ammount)
        {
            _ammount = ammount;
        }
        public String GetOrderStatus()
        {
            return _orderStatus;
        }
        public void SetOrderStatus(String orderStatus)
        {
            _orderStatus = orderStatus;
        }
    }
}
