using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Models
{
    public class Admin : User
    {
        public string _function;

        public Admin()
        {

        }
        public Admin(string type, int id, string email, string password, string function) :base(type,id,email,password)
        {
            this._function = function;
        }
        public Admin(String proprietati) : base(proprietati)
        {
            string[] atribute = proprietati.Split(',');

            _function = atribute[4];
        }
        public override string ToString()
        {

            return base.ToString() + "\n" + "Status: " + _function + '\n';

        }
    }
}
