using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Models
{
    public class Product
    {
        private String _id;
        private String _name;
        private int _price;
        private String _description;
        private DateTime _createDate;
        private int _stock;

        public Product()
        {
            
        }
        public Product(string id, string name, int price, string description,String createDate, int stock)
        {
            _id = id;
            _name = name;
            _price = price;
            _description = description;
            _createDate = DateTime.Parse(createDate);
            _stock = stock;
        }
        public Product(String proprietati)
        {         
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _name = atribute[1];
            _price = Int32.Parse(atribute[2]);
            _description = atribute[3];
            _createDate = DateTime.Parse(atribute[4]);
            _stock = Int32.Parse(atribute[5]);
        }
        public String GetProductDescription()
        {
            String text = "";
            text += "ID: " + _id + "\n"; 
            text += "Name: " + _name + "\n";
            text += "Price: " + _price + "$" + "\n";
            text += "Description: " + _description + "\n";
            text += "Creation Date: " + _createDate + "\n"; 
            text += "Stock: " + _stock + " pcs "  + "\n";
            return text;
        }
        public String GetProductID()
        {
            return this._id;
        }
        public void SetProductID(String id)
        {
            _id = id;
        }
        public String GetProductName()
        {
            return this._name;
        }
        public void SetProductName(String name)
        {
            _name = name;
        }
        public int GetPrice()
        {
            return this._price;
        }
        public void SetPrice(int price)
        {
            _price = price;
        }
        public String GetDescription()
        {
            return _description;
        }
        public void SetDescription(String description)
        {
            _description = description;
        }
        public DateTime GetCreationDate()
        {
            return _createDate;
        }
        public void SetCreationDate(DateTime createDate)
        {
            _createDate = createDate;
        }
        public int GetStock()
        {
            return this._stock;
        }
        public void SetStock(int stock)
        {
            _stock = stock;
        }
    }
}
