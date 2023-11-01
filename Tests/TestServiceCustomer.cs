using online_shop.Models;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestServiceCustomer
    {
        [Fact]
        public void testFindCustomerByIdTrue()
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
            Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

            _customerList.Add(customer1);
            _customerList.Add(customer2);

            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            Assert.True(_serviceCustomer.FindCustomerByID(customer1));
        }
        [Fact]
        public void testFindCustomerByIdFalse()
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
            Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);
            Customer customer3 = new Customer("3C", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

            _customerList.Add(customer1);
            _customerList.Add(customer2);

            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            Assert.False(_serviceCustomer.FindCustomerByID(customer3));
        }
        [Fact]
        public void testAddCustomerTrue()
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
            Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);
            Customer customer3 = new Customer("3C", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

            _customerList.Add(customer1);
            _customerList.Add(customer2);



            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);
            _serviceCustomer.AddCustomer(customer3);

            Assert.True(_serviceCustomer.FindCustomerByID(customer3));
        }
        [Fact]
        public void testAddCustomerFalse()
        {
           
                List<Customer> _customerList = new List<Customer>();

                Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
                Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);
                Customer customer3 = new Customer("3C", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

                _customerList.Add(customer1);
                _customerList.Add(customer2);



                ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);
                _serviceCustomer.AddCustomer(customer2);

                Assert.False(_serviceCustomer.AddCustomer(customer2));            
        }
        [Fact]
        public void testRemoveCustomerTrue() //Verific daca merge remove, true - inseamna ca merge, am pus Assert False ca sa stiu ca elementul nu mai e in lista
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
            Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);
            Customer customer3 = new Customer("3C", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

            _customerList.Add(customer1);
            _customerList.Add(customer2);

            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            _serviceCustomer.RemoveCustomer("1A");

            Assert.False(_serviceCustomer.FindCustomerByID(customer1));
        }
        [Fact]
        public void testRemoveCustomerFalse() //Verific daca merge remove, false - inseamna ca nu merge, am pus Assert True ca sa stiu ca elementul  mai e in lista
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);
            Customer customer2 = new Customer("2B", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);
            Customer customer3 = new Customer("3C", "customer2@mail.com", "aaa", "Graham Jarvis", 0721234142);

            _customerList.Add(customer1);
            _customerList.Add(customer2);

            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            string id = "x";

            Assert.False(_serviceCustomer.RemoveCustomer(id));
        }
        [Fact]
        public void testUpdateCustomerTrue()
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);

            _customerList.Add(customer1);
           
            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            Assert.True(_serviceCustomer.UpdateCustomer("1A", "a", "a", "a", 1, "aX"));
        }
        [Fact]
        public void testUpdateCustomerFalse()
        {
            List<Customer> _customerList = new List<Customer>();

            Customer customer1 = new Customer("1A", "customer1@mail.com", "aaa", "John Greenwood", 0712345689);

            _customerList.Add(customer1);

            ServiceCustomer _serviceCustomer = new ServiceCustomer(_customerList);

            Assert.False(_serviceCustomer.UpdateCustomer("2z", "a", "a", "a", 1, "aX"));
        }

    }
}