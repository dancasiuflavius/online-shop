using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Models
{
    public class User
    {
        private int _id;
        private string _email;
        private string _password;
        private string _type;

        public User()
        {

        }
        public User(string type, int id, string email, string password)
        {
            this._type = type;
            this._id = id;            
            this._email = email;
            this._password = password;
        }
        public User(String proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _type = atribute[0];
            _id = Int32.Parse(atribute[1]);
            _email = atribute[2];
            _password = atribute[3];           
        }
        //public virtual String Description()
        //{
        //    String text = "";
        //    text += "Type: " + _type + '\n';
        //    text += "ID: " + _id + '\n';
        //    text += "Mail: " + _email + '\n';
        //    text += "Password: " + _password + '\n';
        //    return text;
        //}
        public string GetType()
        {
            return _type;
        }
        public void SetType(string type)
        {
            this._type = type;
        }
        public int GetID()
        {
            return _id;
        }
        public void SetID(int id)
        {
            this._id = id;
        }      
        public string GetEmail()
        {
            return _email;
        }
        public void SetEmail(string email)
        {
            this._email = email;
        }
        public string GetPassword()
        {
            return _password;
        }
        public void SetPassword(string password)
        {
            this._password = password;
        }

        public override string ToString()
        {
            return "ID: " + _id + '\n' + "Email: " + _email + '\n' + "Password: " + _password;
        }
        public override bool Equals(object? obj)
        {

            User user = obj as User;


            return this._email.Equals(user._email);

        }


        public virtual string ToSave()
        {

            return _type +"," +_id + "," + _email + "," + _password;
        }

    }
}
