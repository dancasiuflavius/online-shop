using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Users.Service
{
    public class UserQuerryServiceSingleton
    {
        private static readonly IUserQuerryService _instance = new UserQuerryService();

        public static IUserQuerryService Instance => _instance;

        private UserQuerryServiceSingleton() { }
    }
}
