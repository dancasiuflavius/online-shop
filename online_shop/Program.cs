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
        //Console.WriteLine( _serviceUser.ToString());

        //User user = new Customer("customer", 100, "customer1@mail", "123", "ZZZ", "Bucuresti", 077771212);
        //User user1 = new Customer("customer", 252, "customer2@mail", "123", "YYY", "Timisoara", 077771212);
        //User user3 = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");

        //_serviceUser.AddUser(user);
        //_serviceUser.AddUser(user1);
        //_serviceUser.AddUser(user3);

        //_serviceUser.SaveUser();

        //ServiceOrderDetails _srvOrder = new ServiceOrderDetails();

        OrderDetails order = new OrderDetails("OD3", "O5", "P154", 2000, 3);
        //OrderDetails oder1 = new OrderDetails("OD5", "O35", "P212", 500, 3);
        //_srvOrder.AddOrderDetails(order);
        //_srvOrder.AddOrderDetails(oder1);

        //_srvOrder.SaveOrderDetails();

        //ServiceOrderDetails srvOrd = new ServiceOrderDetails();

        //string id = "";

        //id = srvOrd.NextID();

        //Console.WriteLine(id);

        //Console.WriteLine(_serviceUser.RemoveUser(user3));

        //_serviceUser.UpdateUser(new online_shop.DTO.UpdateUser {id=5, type = "admin", newMail = "yahoo.com", newAdress = "Sibiu", newFullName = "Flavius Dancasiu", newPasword = "xtzu", newPhone = 077777777, newFunction = "high permission"});
        //Console.WriteLine( _serviceUser.ToString());

        ViewCustomer viewUser = new ViewCustomer();
        viewUser.Play();

        //ServiceOrderDetails oD = new ServiceOrderDetails();
        //oD.ShowOrderDetails();
       // ServiceOrderDetails OD = new ServiceOrderDetails();
        //List<OrderDetails> orders = new List<OrderDetails>();
        //orders.Add(OD.GetOrderDetailsByOrderID(order.GetID()));
        //orders.Add(order);
        //orders.Add(oder1);
        //OD.ShowOrderDetails2(orders, order.GetID());


        //ServiceOrders orders = new ServiceOrders();
        //orders.ShowOrders();
    }
}