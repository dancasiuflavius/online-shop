using online_shop.Models;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestServiceUser
    {
        [Fact]
        public void testFindUserByIdTrue()
        {
            List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            _userList.Add(user);
            _userList.Add(user1);

            ServiceUser _serviceUser = new ServiceUser(_userList);

            Assert.True(_serviceUser.isUserById(user.GetID()));
        }
        [Fact]
        public void testFindUserByIdFalse()
        {
            List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            _userList.Add(user);
            

            ServiceUser _serviceUser = new ServiceUser(_userList);

            Assert.False(_serviceUser.isUserById(user1.GetID()));
        }
        [Fact]
        public void testAddUserTrue()
        {
            
                List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            User user3 = new Admin("admin", 5, "admin@mail", "qwer1324", "lowest permission");

            _userList.Add(user);
            _userList.Add(user1);



                ServiceUser _serviceUser = new ServiceUser(_userList);
            //_serviceUser.AddUser(user3);

                Assert.True(_serviceUser.isUserById(user3.GetID()));
            
        }
        [Fact]
        public void testAddUserFalse()
        {

            List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            User user3 = new Admin("admin", 5, "admin@mail", "qwer1324", "lowest permission");

            _userList.Add(user);
            _userList.Add(user1);



            ServiceUser _serviceUser = new ServiceUser(_userList);
            //_serviceUser.AddUser(user3);

           // Assert.False(_serviceUser.AddUser(user3));

        }
        [Fact]
        public void testRemoveCustomerTrue() //Verific daca merge remove, true - inseamna ca merge, am pus Assert False ca sa stiu ca elementul nu mai e in lista
        {
            List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            User user3 = new Admin("admin", 5, "admin@mail", "qwer1324", "lowest permission");

            _userList.Add(user);
            _userList.Add(user1);

            ServiceUser _serviceUser = new ServiceUser(_userList);

            _serviceUser.RemoveUser(user);

            Assert.False(_serviceUser.isUserById(user.GetID()));
        }
        [Fact]
        public void testRemoveCustomerFalse() //Verific daca merge remove, false - inseamna ca nu merge, am pus Assert True ca sa stiu ca elementul  mai e in lista
        {
            List<User> _userList = new List<User>();

            User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
            User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
            User user3 = new Admin("admin", 5, "admin@mail", "qwer1324", "lowest permission");

            _userList.Add(user);
            _userList.Add(user1);

            ServiceUser _serviceUser = new ServiceUser(_userList);

           

            Assert.False(_serviceUser.RemoveUser(user3));
        }

    }
}
