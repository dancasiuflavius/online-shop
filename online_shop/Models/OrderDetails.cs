using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Models
{
    public class OrderDetails
    {
        private String _id;
        private String _order_id;
        private String _product_id;
        private int _price;
        private int _quantity;

        public OrderDetails()
        {

        }
        public OrderDetails(string id, string order_id, string product_id, int price, int quantity)
        {
            _id = id;
            _order_id = order_id;
            _product_id = product_id;
            _price = price;
            _quantity = quantity;
        }
        public OrderDetails(String proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _order_id = atribute[1];
            _product_id = atribute[2];
            _price = Int32.Parse(atribute[3]);
            _quantity = Int32.Parse(atribute[4]);
        }
        public String GetOrderDetails()
        {
            String text = "";
            text += "ID: " + _id + "\n";
            text += "Order ID: " + _order_id + "\n";
            text += "Product ID: " + _product_id + "\n";
            text += "Price: " + _price + "$" + "\n";
            text += "Quantity: " + _quantity + "pcs " + "\n";
            return text;
        }

        public String GetID()
        {
            return _id;
        }
        public void SetID(String id)
        {
            _id = id;
        }
        public String GetOrderID()
        {
            return _order_id;
        }
        public void SetOrderID(String order_id)
        {
            _order_id = order_id;
        }
        public String GetProductID()
        {
            return _product_id;
        }
        public void SetProductID(String product_id)
        {
            _product_id = product_id;
        }
        public int GetPrice()
        {
            return _price;
        }
        public void SetPrice(int price)
        {
            _price = price;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
        public virtual string ToSave()
        {

            return _id + "," + _order_id + "," + _product_id + "," + _price + "," + _quantity;
        }

    }
}
