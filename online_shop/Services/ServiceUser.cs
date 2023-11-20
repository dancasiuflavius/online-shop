using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public override string ToString()
        {

            String text = "";

            for(int i=0;i< _usersList.Count; i++)
            {
                text += _usersList[i].ToString() + "\n";

            }

            return text;
        }
    }
}
