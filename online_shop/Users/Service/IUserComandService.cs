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
        void AddUser(User user);
        void RemoveUser(User user);
        void UpdateUser(UpdateUser user);
        void SaveUser();
    }
}
    