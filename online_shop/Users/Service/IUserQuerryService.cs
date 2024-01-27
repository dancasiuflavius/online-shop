using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Users.Service
{
    public interface IUserQuerryService
    {
        bool isUserById(int id);
        User findUserById(int id);
        User findUserByEmailAndPassword(string email, string password);
        void ReadUser();
    }
}
