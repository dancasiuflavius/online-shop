using online_shop.Common;
using online_shop.Models;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewCustomer : ViewUser
    {
        private ServiceUser _serviceUser;
        private ServiceOrders _serviceOrders;
        private ServiceProducts _serviceProducts;
        private ServiceOrderDetails _serviceOrderDetails;
        private Cos _cos;
        public ViewCustomer():base()
        {
            _serviceUser = new ServiceUser();
            _serviceOrders = new ServiceOrders();
            _serviceProducts = new ServiceProducts();
            _serviceOrderDetails = new ServiceOrderDetails();
            _cos = new Cos();
        }
        public override void Meniu()
        {
            base.Meniu();
            Console.WriteLine("Apasati tasta 5 pentru a adauga produse in cos");
            Console.WriteLine("Apasati tasta 6 pentru a afisa cosul de cumparaturi.");
        }
        public void AddProductsInBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Console.WriteLine("Introduceti cantitatea dorita.");
            int qty = 0;
            qty = Int32.Parse(Console.ReadLine());
            Product product = new Product();
            if (_serviceProducts.BuyProduct(productName, qty) != null)
            {
                product = _serviceProducts.BuyProduct(productName, qty);
                product.SetStock(qty);
                _cos.AddProductInBasket(product);
                
            }
            else
                Console.WriteLine("Cantitate indisponibila sau produs inexistent.");
        
                                   

        }
        public void AccesBasket()
        {
            Console.WriteLine("|~~~~~~~YOUR BASKET~~~~~~~~|");
                ViewCos viewCos = new ViewCos();
                viewCos.Play();
             
            
            
        }
        public void Play()
        {
            bool running = true;

            int alegere = 0;

            while (running)
            {
                Meniu();

                alegere = Int32.Parse(Console.ReadLine());


                switch (alegere)
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        ShowAscByPrice();
                        break;
                    case 3:
                        ShowDscByPrice();
                        break;
                    case 4:
                        ShowByDate();
                        break;
                    case 5:
                        AddProductsInBasket();
                        
                        
                        break;
                    case 6:
                        _cos.ShowBasketProducts();
                        break;
                    default:

                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }
    }
}
