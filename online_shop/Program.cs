using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
using online_shop.Views;
using online_shop.Common;

internal class Program
{
    private static void Main(string[] args)
    {
        //ServiceUser _serviceUser = new ServiceUser();
        ////Console.WriteLine( _serviceUser.ToString());

        //User user = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
        //User user1 = new Customer("customer", 2, "customer2@mail", "123", "Daniel", "Sibiu Cisnadie Str Tiberiu Ricci 20", 077771212);
        //User user3 = new Admin("admin", 5, "admin@mail", "qwer1324", "lowest permission");

        //_serviceUser.AddUser(user);
        //_serviceUser.AddUser(user3);

        //Console.WriteLine(_serviceUser.RemoveUser(user3));

        //_serviceUser.UpdateUser(new online_shop.DTO.UpdateUser {id=5, type = "admin", newMail = "yahoo.com", newAdress = "Sibiu", newFullName = "Flavius Dancasiu", newPasword = "xtzu", newPhone = 077777777, newFunction = "high permission"});
        //Console.WriteLine( _serviceUser.ToString());

        ViewCustomer viewCustomer = new ViewCustomer();
        viewCustomer.Play();

        //ServiceOrderDetails oD = new ServiceOrderDetails();
        //oD.ShowOrderDetails();


        //ServiceOrders orders = new ServiceOrders();
        //orders.ShowOrders();

        //Product product = new Product("P1", "Iphone", 1200, "Iphone 13 Pro", "05 / 05 / 2021", 10);
        //Cos cos = new Cos();
        //ServiceProducts serviceProducts = new ServiceProducts();
        //Product product1 = new Product();
        //product1 = serviceProducts.BuyProduct("Iphone",12);       
        //cos.AddProductInBasket(product1);
        //cos.ShowBasketProducts();


    }
}