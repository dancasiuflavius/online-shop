using online_shop.DTO;
using online_shop.Models;
using online_shop.OrderDetail;
using online_shop.OrderDetail.Service;
using online_shop.Orders.Service;
using online_shop.Products.Model;
using online_shop.Products.Serivce;
using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewAdmin
    {
        private Admin admin;
        private IProductComandService _productComandService;
        private IProductQuerryService _productQuerryService;
        private IOrderDetailsComandService _orderDetailsComandService;
        private IOrderDetailsQuerryService _orderDetailsQuerryService;
        private IOrderComandService _orderComandService;
        private IOrderQuerryService _orderQuerryService;
        public ViewAdmin()
        {
            admin = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");
            _productComandService = ProductComandServiceSingleton.Instance;
            _productQuerryService = ProductQuerryServiceSingleton.Instance;
            _orderDetailsComandService = OrderDetailComandServiceSingleton.Instance;
            _orderDetailsQuerryService = OrderDetailQuerryServiceSingleton.Instance;
            _orderComandService = OrderComandServiceSingleton.Instance;
            _orderQuerryService = OrderQuerryServiceSingleton.Instance;
        }

        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa produse din magazin.");
            Console.WriteLine("Apasati tasta 2 pentru a adauga produse in magazin.");
            Console.WriteLine("Apasati tasta 3 pentru a sterge produse din magazin.");
            Console.WriteLine("Apasati tasta 4 pentru a modifica produse din magazin.");
        }
        public void AddProduct()
        {

            string id;
            string name;
            int price;
            string desc;
            DateTime date;
            int stock;

            id = _productQuerryService.NextID();
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

            _productComandService.AddProduct(product);
            _productComandService.SaveProduct();
            _productQuerryService.ReadProduct();
        }
        public void RemoveProduct()
        {
            Console.WriteLine("Introduceti ID-ul produsului pe care il stergeti.");
            string id;
            id = Console.ReadLine();
            _productComandService.RemoveProduct(id);
            _productComandService.SaveProduct();
            _productQuerryService.ReadProduct();
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

            _productComandService.UpdateProduct(id, name, price, desc, date, stock, newId);
            _productComandService.SaveProduct();
            _productQuerryService.ReadProduct();

        }
        public void ShowProducts()
        {
            _productQuerryService.ShowProducts();
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
                        AddProduct();
                        break;
                    case 3:
                        RemoveProduct();
                        break;
                    case 4:
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

