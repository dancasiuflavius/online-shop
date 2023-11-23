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
        private ServiceUser _serviceUser;
        private ServiceOrders _serviceOrders;
        private ServiceProducts _serviceProducts;
        private ServiceOrderDetails _serviceOrderDetails;

        //User customer1 = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);

        public ViewUser()
        {
            _serviceUser = new ServiceUser();
            _serviceOrders = new ServiceOrders();
            _serviceProducts = new ServiceProducts();
            _serviceOrderDetails = new ServiceOrderDetails();
        }



        public virtual  void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa lista de produse");
            Console.WriteLine("Apasati tasta 2 pentru a afisa produsele in ordine crescatoare dupa pret.");
            Console.WriteLine("Apasati tasta 3 pentru a afisa produsele in ordine crescatoare dupa pret.");
            Console.WriteLine("Apasati tasta 4 pentru a afisa produsele dupa data.");

        }

        public void ShowProducts()
        {
            _serviceProducts.ShowProducts();
        }
        public void ShowAscByPrice()
        {          
            _serviceProducts.AscendingSortByPrice();
            _serviceProducts.ShowProducts();
        }
        public void ShowDscByPrice()
        {
            _serviceProducts.DescendingSortByPrice();
            _serviceProducts.ShowProducts();
        }
        public void ShowByDate()
        {
            _serviceProducts.SortDate();
            _serviceProducts.ShowProducts();
        }


       
    }
}
