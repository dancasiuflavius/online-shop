using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using online_shop.DTO;
using online_shop.Products.Model;
using online_shop.Services;
using online_shop.Users.Models;

namespace online_shop.Views
{
    public class ViewAdmin : ViewUser
    {
        private Admin admin;
        public ViewAdmin()
        {
            admin = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");
        }
        public void Meniu()
        {
            base.Meniu();
            Console.WriteLine("Apasati tasta 3 pentru a adauga produse in magazin.");
            Console.WriteLine("Apasati tasta 4 pentru a sterge produse din magazin.");
            Console.WriteLine("Apasati tasta 5 pentru a modifica produse din magazin.");
        }
        public void AddProduct()
        {
            
            string id;
            string name;
            int price;
            string desc;
            DateTime date;
            int stock;

            id = _serviceProducts.NextID();
            Console.WriteLine("Introduceti numele produsului.");
            name = Console.ReadLine();
            Console.WriteLine("Introduceti pretul produsului.");
            price = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti descrierea produsului.");
            desc = Console.ReadLine();
            Console.WriteLine("Introduceti data fabricatiei.");
            date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti stocul.");
            stock = Int32.Parse(Console.ReadLine());

            Product product = new Product(id, name, price, desc, date.ToString(), stock);

            _serviceProducts.AddProduct(product);
            _serviceProducts.SaveProduct();
        }
        public void RemoveProduct()
        {
            Console.WriteLine("Introduceti ID-ul produsului pe care il stergeti.");
            string id;
            id = Console.ReadLine();
            _serviceProducts.RemoveProduct(id);
            _serviceProducts.SaveProduct();
        }
        public void UpdateProduct()
        {
            string id;
            Console.WriteLine("Introduceti ID-ul produsului pe care il modificati.");
            id = Console.ReadLine();

            string name;
            int price;
            string desc;
            DateTime date;
            int stock;
            string newId;

            Console.WriteLine("Introduceti numele produsului.");
            name = Console.ReadLine();
            Console.WriteLine("Introduceti pretul produsului.");
            price = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti descrierea produsului.");
            desc = Console.ReadLine();
            Console.WriteLine("Introduceti data fabricatiei.");
            date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti stocul.");
            stock = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti noul ID al produsului.");
            newId = Console.ReadLine();

            _serviceProducts.UpdateProduct(id, name, price, desc, date, stock, newId);
            _serviceProducts.SaveProduct();

        }
        public void ShowProducts()
        {
            _serviceProducts.ShowProducts();
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
                    case 3:
                        AddProduct();
                        break;
                    case 4:
                        RemoveProduct();
                        break;
                    case 5:
                        UpdateProduct();
                        break;
                        
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }

        }
    }
}
