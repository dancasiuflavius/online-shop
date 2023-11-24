using online_shop.DTO;
using online_shop.Models;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewCustomer:ViewUser
    {

       

        private Cos _cos;
        private User customer;

        public ViewCustomer()
        {
          
            _cos = new Cos();
            customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
        }



        public void Meniu()
        {
            base.Meniu();
            Console.WriteLine("Apasati tasta 5 pentru a adauga produse in cos");
            Console.WriteLine("Apasati tasta 6 pentru a afisa cosul de cumparaturi.");

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
                        ShowOrderDetails();
                        break;
                    case 5:
                        AddProductsInBasket();
                        break;
                    case 6:
                        Console.WriteLine(this._cos);
                        break;


                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }

     

        public void AddProductsInBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Console.WriteLine("Introduceti cantitatea dorita.");
            int qty = 0;
            qty = Int32.Parse(Console.ReadLine());

        

            Product product = _serviceProducts.FindProductByName(productName);
            if(product != null)
            {
                ProductDto productDto = new ProductDto(product, qty);
                this._cos.AddProduct(productDto);
                Console.WriteLine(  "Produsul  a fost adaugat cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }

           


        }




    }
}
