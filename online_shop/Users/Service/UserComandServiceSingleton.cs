using online_shop.Products.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Users.Service
{
    public class UserComandServiceSingleton
    {
        private static readonly IUserComandService _instance = new UserComandService();

        public static IUserComandService Instance => _instance;

        private UserComandServiceSingleton() { }
    }
}
