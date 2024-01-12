using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Model
{
    public class Product
    {
        private string _id;
        private string _name;
        private int _price;
        private string _description;
        private DateTime _createDate;
        private int _stock;

        public Product()
        {

        }
        public Product(string id, string name, int price, string description, string createDate, int stock)
        {
            _id = id;
            _name = name;
            _price = price;
            _description = description;
            _createDate = DateTime.Parse(createDate);
            _stock = stock;
        }
        public Product(string proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _name = atribute[1];
            _price = int.Parse(atribute[2]);
            _description = atribute[3];
            _createDate = DateTime.Parse(atribute[4]);
            _stock = int.Parse(atribute[5]);
        }
        public string GetProductDescription()
        {
            string text = "";
            text += "ID: " + _id + "\n";
            text += "Name: " + _name + "\n";
            text += "Price: " + _price + "$" + "\n";
            text += "Description: " + _description + "\n";
            text += "Creation Date: " + _createDate + "\n";
            text += "Stock: " + _stock + " pcs " + "\n";
            return text;
        }
        public string GetProductID()
        {
            return _id;
        }
        public void SetProductID(string id)
        {
            _id = id;
        }
        public string GetProductName()
        {
            return _name;
        }
        public void SetProductName(string name)
        {
            _name = name;
        }
        public int GetPrice()
        {
            return _price;
        }
        public void SetPrice(int price)
        {
            _price = price;
        }
        public string GetDescription()
        {
            return _description;
        }
        public void SetDescription(string description)
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
            return _stock;
        }
        public void SetStock(int stock)
        {
            _stock = stock;
        }
        public virtual string ToSave()
        {
            return _id + "," + _name + "," + _price + "," + _description + "," + _createDate + "," + _stock;
        }
    }
}
