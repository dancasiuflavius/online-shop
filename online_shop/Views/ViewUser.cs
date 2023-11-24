using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Services;

namespace online_shop.Views
{
    public class ViewUser
    {
        protected ServiceUser _serviceUser;
        protected ServiceOrders _serviceOrders;
        protected ServiceProducts _serviceProducts;
        protected ServiceOrderDetails _serviceOrderDetails;

        //User customer1 = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);

        public ViewUser()
        {
            _serviceUser = new ServiceUser();
            _serviceOrders = new ServiceOrders();
            _serviceProducts = new ServiceProducts();
            _serviceOrderDetails = new ServiceOrderDetails();
        }



        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa lista de produse");
            Console.WriteLine("Apasati tasta 2 pentru a afisa detaliile comenzii");
                  
        }

        public void ShowProducts()
        {
            _serviceProducts.ShowProducts();
        }
        public void ShowOrderDetails()
        {
            _serviceOrderDetails.ShowOrderDetails();
        }


       
    }
}
