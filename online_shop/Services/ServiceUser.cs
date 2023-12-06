using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using online_shop.DTO;
using online_shop.Models;

namespace online_shop.Services
{
    public class ServiceUser
    {
        private List<User> _usersList;

        private String _filePath;

        public ServiceUser()
        {
            _usersList = new List<User>();
            _filePath = GetDirectory();

            this.ReadUser();
        }
        public ServiceUser(List<User> users)
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
                                this._usersList.Add(new Customer(line));
                                break;
                            case "admin":
                                this._usersList.Add(new Admin(line));
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
        //public bool AddUser(User user)
        //{
        //    switch (user)
        //    {
        //        case Customer customer when isUserById(customer.GetID()) == false: //Daca user este customer, modificam user in Customer, cautam in lista, daca e fals adaugam
        //            _usersList.Add(customer);
        //            return true;

        //        case Admin admin when isUserById(admin.GetID()) == false:
        //            _usersList.Add(admin);
        //            return true;

        //        default:
        //            return false;
        //    }
        //}
        public bool RemoveUser(User user)
        {
            switch (user)
            {
                case Customer customer when isUserById(customer.GetID()) == true: 
                    _usersList.Remove(customer);
                    return true;

                case Admin admin when isUserById(admin.GetID()) == true:
                    _usersList.Remove(admin);
                    return true;

                default:
                    return false;
            }

        }
        public bool UpdateUser(UpdateUser user)
        {
            switch (user.type)
            {
                case "customer":
                    Customer customer=findUserById(user.id) as Customer;
                    customer.SetPhone(user.newPhone);
                    customer.SetEmail(user.newMail);
                    customer.SetPassword(user.newPasword);
                    customer.SetAdress(user.newAdress);
                    customer.SetFullName(user.newFullName);
                   
                    return true;

                case "admin":
                    Admin admin = findUserById(user.id) as Admin;
                    admin.SetFunction(user.newFunction);
                    admin.SetEmail(user.newMail);
                    admin.SetPassword(user.newPasword);
                                     
                    return true;


                default:
                    return false;
            }
        }


        public override string ToString()
        {

            String text = "";

            for(int i=0;i< _usersList.Count; i++)
            {
                text += _usersList[i].ToString() + "\n";

            }

            return text;
        }


        public  String toSave()
        {

            String text = "";
            int i = 0;
            for (i = 0; i < _usersList.Count - 1; i++)
            {

                text += _usersList[i].ToSave() + "\n";
            }

            text += _usersList[i].ToSave();

            return text;
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
    }
}
