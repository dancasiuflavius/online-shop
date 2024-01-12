using online_shop.DTO;
using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Users.Service
{
    public interface IUserComandService
    {
        bool AddUser(User user);
        bool RemoveUser(User user);
        bool UpdateUser(UpdateUser user);
        void SaveUser();
    }
}
    