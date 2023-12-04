using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace online_shop.Models
{
    public class Customer : User
    {
        
        public String _fullName;
        public String _adress;
        public int _phone;

        public Customer()
        {

        }
        public Customer(string type, int id, string email, string password, string fullName, string adress, int phone) : base (type, id, email, password)
        {          
            _fullName = fullName;
            _adress = adress;
            _phone = phone;
        }
        public Customer(String proprietati) : base (proprietati)
        {
            string[] atribute = proprietati.Split(',');
            
            _fullName = atribute[4];
            _adress = atribute[5];
            _phone = Int32.Parse(atribute[6]);
        }

        //public override String Description()
        //{
        //    String text = "";
        //    text += "Full Name: " + _fullName + '\n';
        //    text += "Adress: " + _adress + '\n';
        //    text += "Phone: " + _phone + '\n';

        //    return text;
        //}
        public String GetFullName()
        {
            return _fullName;
        }
        public void SetFullName(String fullName)
        {
            _fullName = fullName;
        }
        public String GetAdress()
        {
            return _adress;
        }
        public void SetAdress(String adress)
        {
            this._adress = adress;
        }
        public int GetPhone()
        {
            return _phone;
        }
        public void SetPhone(int phone)
        {
            _phone = phone;
        }
        public override string ToString()
        {

            return base.ToString()+"\n"+"Full Name: " + _fullName + '\n' + "Adress: " + _adress + '\n' + "Phone: " + _phone + '\n';

        }

        public override string ToSave()
        {
            return base.ToSave() +","+ _fullName + "," + _adress + ","  + _phone;
        }


    }
}
