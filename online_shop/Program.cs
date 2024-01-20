using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
using online_shop.Views;
using online_shop.OrderDetail;
using online_shop.Orders;
using online_shop.Orders.Service;

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

        ViewCustomer view = new ViewCustomer();
        view.Play();
    }
}