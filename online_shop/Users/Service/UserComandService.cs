using online_shop.DTO;
using online_shop.Models;
using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Users.Exceptions;
using online_shop.Utils;

namespace online_shop.Users.Service
{
    public class UserComandService : IUserComandService
    {
        private List<User> _usersList;

        private string _filePath;

        public UserComandService()
        {
            _usersList = new List<User>();
            _filePath = GetDirectory();

            ReadUser();
        }
        public UserComandService(List<User> users)
        {
            _usersList = users;

        }
        public string GetDirectory()
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
        private bool isUserById(int id)
        {
            for (int i = 0; i < _usersList.Count; i++)
                if (_usersList[i].GetID() == id)
                    return true;
            return false;
        }
        private User findUserById(int id)
        {
            User user = null;
            for (int i = 0; i < _usersList.Count; i++)
                if (_usersList[i].GetID() == id)
                {
                    return _usersList[i];
                }
            return user;
        }
        //private User FindUserById(int id)
        //{
        //    return _usersList.FirstOrDefault(user => user.GetID() == id);
        //}

        public void AddUser(User user)
        {
            switch (user)
            {
                case Customer customer when isUserById(customer.GetID()) == false: //Daca user este customer, modificam user in Customer, cautam in lista, daca e fals adaugam
                    _usersList.Add(customer);
                    break;
                   

                case Admin admin when isUserById(admin.GetID()) == false:
                    _usersList.Add(admin);
                    break;
                   

                default:
                    throw new UserNotFoundException(Constants.UserNotFoundMessage);
            }
        }
        public void RemoveUser(User user)
        {
            switch (user)
            {
                case Customer customer when isUserById(customer.GetID()) == true:
                    _usersList.Remove(customer);
                    break;

                case Admin admin when isUserById(admin.GetID()) == true:
                    _usersList.Remove(admin);
                    break;

                default:
                    throw new UserNotFoundException(Constants.UserNotFoundMessage);
            }

        }
        public void UpdateUser(UpdateUser user)
        {
            switch (user.type)
            {
                case "customer":
                    Customer customer = findUserById(user.id) as Customer;
                    customer.SetPhone(user.newPhone);
                    customer.SetEmail(user.newMail);
                    customer.SetPassword(user.newPasword);
                    customer.SetAdress(user.newAdress);
                    customer.SetFullName(user.newFullName);

                    break;

                case "admin":
                    Admin admin = findUserById(user.id) as Admin;
                    admin.SetFunction(user.newFunction);
                    admin.SetEmail(user.newMail);
                    admin.SetPassword(user.newPasword);

                    break;


                
                default:
                    throw new UserNotFoundException(Constants.UserNotFoundMessage);
            }
        }
        public void SaveUser()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamWriter reader = new StreamWriter(filePath))
                {
                    // Read and process the file line by line

                    reader.Write(toSave());

                    reader.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        private string toSave()
        {

            string text = "";
            int i = 0;
            for (i = 0; i < _usersList.Count - 1; i++)
            {

                text += _usersList[i].ToSave() + "\n";
            }

            text += _usersList[i].ToSave();

            return text;
        }

        
    }
}
