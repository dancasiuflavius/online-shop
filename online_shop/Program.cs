using online_shop.Models;
using online_shop.Services;
using System.ComponentModel.Design;
using System.Numerics;
internal class Program
{
    private static void Main(string[] args)
    {
        ServiceCustomer customer = new ServiceCustomer();
        Customer customer1 = new Customer("1A", "  customer1@mail.com", "aaa", "John Greenwood", 0712345689);
        customer.ShowCustomers();
        customer.RemoveCustomer("1A");
        customer.ShowCustomers();

    }
}