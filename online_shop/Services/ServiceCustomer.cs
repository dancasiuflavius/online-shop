using online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Services
{
    public class ServiceCustomer
    {
        private List<Customer> _customerList;

        private String _filePath;

        public ServiceCustomer()
        {
            _customerList = new List<Customer>();
            _filePath = GetDirectory();

            this.ReadCustomer();
        }
        public ServiceCustomer(List<Customer> customers)
        {
            _customerList = customers;

        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "customers.txt");

            return filePath;
        }
        public void ReadCustomer()
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
                        _customerList.Add(new Customer(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowCustomers()
        {
            for (int i = 0; i < _customerList.Count; i++)
                Console.WriteLine(_customerList[i].GetCustomerDescription());
        }
        public bool FindCustomerByID(Customer customer)
        {
            for (int i = 0; i < _customerList.Count(); i++)
            {
                if (customer.GetCustomerID().Equals(_customerList[i].GetCustomerID()))
                    return true;
            }

            return false;
        }
        public bool AddCustomer(Customer customer)
        {
            if (FindCustomerByID(customer) == true)
                return false;
            else
                _customerList.Add(customer);
            return true;
        }
        public bool RemoveCustomer(String id)
        {
            for (int i = 0; i < _customerList.Count; i++)
            {
                if (_customerList[i].GetCustomerID().Equals(id))
                {
                    _customerList.RemoveAt(i);
                    return true;
                    
                }
            }
            return false;
            
        }
        public bool UpdateCustomer(String id, String mail, String password, String fullName, int phone, String newId )
        {
            for (int i = 0; i < _customerList.Count; i++)
            {
                if (_customerList[i].GetCustomerID().Equals(id))
                {
                    _customerList[i].SetEmail(mail);
                    _customerList[i].SetPassword(password);
                    _customerList[i].SetFullName(fullName);
                    _customerList[i].SetPhone(phone);
                    _customerList[i].SetCustomerID(newId);
                    return true;
                }
            }
            return false;
        }
    }
}
