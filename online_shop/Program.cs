using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
using online_shop.Views;
using online_shop.OrderDetail;
using online_shop.Orders;
using online_shop.Orders.Service;
using online_shop.Products.Serivce;
using online_shop.Products.Model;
using online_shop.OrderDetail.Service;
using online_shop.Users.Service;
using online_shop.Users.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<OrderDetails> odList = new List<OrderDetails>();
        //OrderDetails od1 = new OrderDetails("OD982", "O877", "P1", 12000, 10);
        //OrderDetails od2 = new OrderDetails("OD976", "O922", "P1", 12000, 10);
        //odList.Add(od1);
        //odList.Add(od2);
        //OrderDetailsComandService _odComandService = new OrderDetailsComandService(odList);
        //Console.WriteLine(_odComandService.FindOrderDetailsByID("O922"));
        //Console.WriteLine(_odComandService.AddOrderDetails(od1));
        //Console.WriteLine(_odComandService.RemoveOrderDetails("O877"));
        //Console.WriteLine(_odComandService.UpdateOrderDetails("O871", "CCC", "P3", 25, 10, "N2"));

        //List<Order> orderList = new List<Order>();
        //Order order = new Order("O1",100,5,"delivered");
        //Order order1 = new Order("O2", 252, 4, "declined");

        //orderList.Add(order1);
        //orderList.Add(order);

        //OrderComandService _oComandService = new OrderComandService(orderList);
        //Console.WriteLine(_oComandService.AddOrder(order));
        //Console.WriteLine(_oComandService.RemoveOrder("O1"));
        //Console.WriteLine(_oComandService.UpdateOrder("O1", 12, 5, "declined", "O44"));
        //OrderQuerryService _oQService = new OrderQuerryService(orderList);
        //Console.WriteLine(_oQService.FindOrderByID("O3"));


        //Product prod = new Product("P2", "Laptop", 3000, "Asus ROG", "3 / 3 / 2023 12:00:00 AM", 100);
        //List<Product> products = new List<Product>();
        //products.Add(prod);

        //IProductQuerryService productQuerryService = ProductQuerryServiceSingleton.Instance;
        //if (productQuerryService.FindProductByID2("P5") != null)
        //    Console.WriteLine("Exista");
        //else
        //    Console.WriteLine("Nu exista");


        ViewLogin view = new ViewLogin();
        view.Play();

        //IUserQuerryService userQuerryService = UserQuerryServiceSingleton.Instance;
        //Customer _customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 77771212);
        //Admin admin = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");

        //userQuerryService.findUserByEmailAndPassword("admin@mail.com", "qwer1324").ToString();

        //IOrderQuerryService order = OrderQuerryServiceSingleton.Instance;
        //order.ShowOrders();

    }
}