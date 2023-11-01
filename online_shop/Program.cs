using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
internal class Program
{
    private static void Main(string[] args)
    { 
    //    ServiceCustomer customer = new ServiceCustomer();
    //    Customer customer1 = new Customer("1A", "  customer1@mail.com", "aaa", "John Greenwood", 0712345689);
    //    customer.ShowCustomers();
    //    customer.RemoveCustomer("1A");
    //    customer.ShowCustomers();
        string dateStr = "2023-11-01";


        DateTime date1 = DateTime.Parse(dateStr);
        Console.WriteLine("Parsed using DateTime.Parse: " + date1);

        Console.WriteLine(date1.ToShortDateString());


    }
}