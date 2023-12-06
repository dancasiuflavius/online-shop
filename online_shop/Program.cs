using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
using online_shop.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        //ServiceUser _serviceUser = new ServiceUser();
        ////Console.WriteLine( _serviceUser.ToString());

        //User user = new Customer("customer", 100, "customer1@mail", "123", "ZZZ", "Bucuresti", 077771212);
        //User user1 = new Customer("customer", 252, "customer2@mail", "123", "YYY", "Timisoara", 077771212);
        //User user3 = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");

        //_serviceUser.AddUser(user);
        //_serviceUser.AddUser(user1);
        //_serviceUser.AddUser(user3);

        //_serviceUser.SaveUser();

        //Console.WriteLine(_serviceUser.RemoveUser(user3));

        //_serviceUser.UpdateUser(new online_shop.DTO.UpdateUser {id=5, type = "admin", newMail = "yahoo.com", newAdress = "Sibiu", newFullName = "Flavius Dancasiu", newPasword = "xtzu", newPhone = 077777777, newFunction = "high permission"});
        //Console.WriteLine( _serviceUser.ToString());

        ViewCustomer viewUser = new ViewCustomer();
        viewUser.Play();

        //ServiceOrderDetails oD = new ServiceOrderDetails();
        //oD.ShowOrderDetails();


        //ServiceOrders orders = new ServiceOrders();
        //orders.ShowOrders();
    }
}