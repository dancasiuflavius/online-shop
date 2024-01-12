using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Users.Service
{
    public class UserQuerryService : IUserQuerryService
    {
        private List<User> _usersList;

        

        public UserQuerryService()
        {
            _usersList = new List<User>();
            
        }
        public UserQuerryService(List<User> users)
        {
            _usersList = users;

        }
        public bool isUserById(int id)
        {
            for (int i = 0; i < _usersList.Count; i++)
                if (_usersList[i].GetID() == id)
                    return true;
            return false;
        }
        public User findUserById(int id)
        {
            User user = null;
            for (int i = 0; i < _usersList.Count; i++)
                if (_usersList[i].GetID() == id)
                {
                    return _usersList[i];
                }
            return user;
        }
    }
}
