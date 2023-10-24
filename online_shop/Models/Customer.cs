using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace online_shop.Models
{
    public class Customer
    {
        public String _id;
        public String _email;
        public String _password;
        public String _fullName;
        public int _phone;

        public Customer()
        {

        }
        public Customer(string id, string email, string password, string fullName, int phone)
        {
            _id = id;
            _email = email;
            _password = password;
            _fullName = fullName;
            _phone = phone;
        }
        public Customer(String proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _email = atribute[1];
            _password = atribute[2];
            _fullName = atribute[3];
            _phone = Int32.Parse(atribute[4]);
        }
        public String GetCustomerDescription()
        {
            String text = "";
            text += "ID: " + _id + "\n";
            text += "Email: " + _email + "\n";
            text += "Password: " + _password + "$" + "\n";
            text += "Full Name: " + _fullName + "\n";
            text += "Phone: " + _phone + "\n";
            
            return text;
        }
        public String GetCustomerID()
        { return _id; }
        public void SetCustomerID(String id)
        {
            _id = id;
        }
        public String GetEmail()
        {
            return _email;
        }
        public void SetEmail(String email)
        {
            _email = email;
        }
        public String GetPassword()
        {
            return _password;
        }
        public void SetPassword(String password)
        {
            _password = password;
        }
        public String GetFullName()
        {
            return _fullName;
        }
        public int GetPhone()
        {
            return _phone;
        }
        public void SetPhone(int phone)
        {
            _phone = phone;
        }

    }
}
