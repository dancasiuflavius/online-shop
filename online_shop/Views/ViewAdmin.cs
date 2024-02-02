using online_shop.DTO;
using online_shop.Models;
using online_shop.OrderDetail;
using online_shop.OrderDetail.Service;
using online_shop.Orders.Service;
using online_shop.Products.Model;
using online_shop.Products.Serivce;
using online_shop.Users.Models;
using online_shop.Utils;
using online_shop.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Users.Service;
using online_shop.Orders.Exceptions;
using online_shop.Users.Exceptions;

namespace online_shop.Views
{
    public class ViewAdmin
    {
        private Admin _admin;
        private IProductComandService _productComandService;
        private IProductQuerryService _productQuerryService;
        private IUserComandService _userComandService;
        private IUserQuerryService userQuerryService;
        private IOrderDetailsComandService _orderDetailsComandService;
        private IOrderDetailsQuerryService _orderDetailsQuerryService;
        private IOrderComandService _orderComandService;
        private IOrderQuerryService _orderQuerryService;
        public ViewAdmin(Admin admin)
        {
          
            _productComandService = ProductComandServiceSingleton.Instance;
            _productQuerryService = ProductQuerryServiceSingleton.Instance;
            _orderDetailsComandService = OrderDetailComandServiceSingleton.Instance;
            _orderDetailsQuerryService = OrderDetailQuerryServiceSingleton.Instance;
            _orderComandService = OrderComandServiceSingleton.Instance;
            _orderQuerryService = OrderQuerryServiceSingleton.Instance;
            _admin = admin;
            
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
            try
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
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter valid numeric values for price and stock.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public void ShowProducts()
        {
            _productQuerryService.ShowProducts();
        }
        //public void AddUser()
        //{
        //    _userComandService.AddUser();
        //}
        //public void RemoveUser()
        //{
        //    _userComandService.RemoveUser();
        //}
        public void ShowOrder()
        {
            
            _orderQuerryService.ShowOrders();
        }
        public void RemoveOrder()
        {
            
                Console.WriteLine("Introduceti ID-ul comenzii pe care o stergeti.");
                string id = Console.ReadLine();
                _orderComandService.RemoveOrder(id);
                _orderComandService.SaveOrder();            

        }
        public void UpdateOrder()
        {
            try
            {
                string id;
            int customerID;
            int ammount;
            String OrderStatus;
            String newId;
            Console.WriteLine("Introduceti ID-ul comenzii pe care o modificati.");
            id = Console.ReadLine();                       

            Console.WriteLine("Introduceti ID-ul customer-ului .");
            customerID = Int32.Parse(Console.ReadLine());    

            Console.WriteLine("Introduceti valoarea.");
            ammount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti statusul comenzii");
            OrderStatus = Console.ReadLine(); 
            
            Console.WriteLine("Introduceti noul ID al produsului.");
            newId = Console.ReadLine();

            _orderComandService.UpdateOrder(id, customerID, ammount, OrderStatus, newId);
            _orderComandService.SaveOrder();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter valid numeric values for price and stock.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public void AddOrderDetails()
        {
            //?
        }
        public void RemoveOrderDetails()
        {
            Console.WriteLine("Introduceti ID-ul comenzii pe care o stergeti.");
            string id = Console.ReadLine();
            _orderDetailsComandService.RemoveOrderDetails(id);
            _orderDetailsComandService.SaveOrderDetails();
        }
        public void UpdateOrderDetails()
        {
            try
            {
                string id;
                string order_id;
                string product_id;
                int price;
                int qty;
                
                String newId;
                Console.WriteLine("Introduceti ID-ul pt Order Detail.");
                id = Console.ReadLine();

                Console.WriteLine("Introduceti ID-ul comenzii .");
                order_id = Console.ReadLine();

                Console.WriteLine("Introduceti ID-ul produsului .");
                product_id = Console.ReadLine();

                Console.WriteLine("Introduceti pretul.");
                price = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti cantitatea.");
                qty = Int32.Parse(Console.ReadLine());


                Console.WriteLine("Introduceti noul ID al produsului.");
                newId = Console.ReadLine();

                _orderDetailsComandService.UpdateOrderDetails(id, order_id, product_id,price, qty, newId);
                _orderDetailsComandService.SaveOrderDetails();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter valid numeric values for price and stock.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public void ShowOrderDetails()

        {
            _orderDetailsQuerryService.ShowOrderDetails();
        }
        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa produse din magazin.");
            Console.WriteLine("Apasati tasta 2 pentru a adauga produse in magazin.");
            Console.WriteLine("Apasati tasta 3 pentru a sterge produse din magazin.");
            Console.WriteLine("Apasati tasta 4 pentru a modifica produse din magazin.");
            Console.WriteLine("Apasati tasta 5 pentru a afisa comenzile");
            Console.WriteLine("Apasati tasta 6 pentru a sterge o comanda");
            Console.WriteLine("Apasati tasta 7 pentru a modifica o comanda");
            Console.WriteLine("Apasati tasta 8 pentru a sterge un order details");
            Console.WriteLine("Apasati tasta 9 pentru a modificat un order details");
            Console.WriteLine("Apasati tasta 10 pentru a afisa  order details list");
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
                    case 5:
                        ShowOrder();
                        break;
                    case 6:
                        RemoveOrder();
                        break;
                    case 7:
                        UpdateOrder();
                        break;
                    case 8:
                        RemoveOrderDetails();
                        break;
                    case 9:
                        UpdateOrderDetails();
                        break;
                    case 10:
                        ShowOrderDetails();
                        break;
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }

        }
    }
}

