using online_shop.Models;
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
        private string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "users.txt");

            return filePath;
        }
        public void ReadUser()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read and process the file line by line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        switch (line.Split(",")[0])
                        {


                            case "customer":
                                _usersList.Add(new Customer(line));
                                break;
                            case "admin":
                                _usersList.Add(new Admin(line));
                                break;
                            default:
                                Console.WriteLine("eroare citire fisier");
                                break;

                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
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
        public User findUserByEmailAndPassword(string email, string password)
        {
            User user = null;
            for (int i = 0; i < _usersList.Count; i++)
                if (_usersList[i].GetEmail() == email && _usersList[i].GetPassword() == password)
                {
                    return _usersList[i];
                }
            return user;
        }
    }
}
