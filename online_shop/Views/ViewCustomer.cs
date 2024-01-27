using online_shop.DTO;
using online_shop.Models;
using online_shop.OrderDetail;
using online_shop.OrderDetail.Service;
using online_shop.Orders.Service;
using online_shop.Products.Model;
using online_shop.Products.Serivce;
using online_shop.Services;
using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewCustomer
    {

        private Customer _customer;
        private Cos _basket;
        private CreateOrderRequest _order;
        private IProductComandService _productComandService;
        private IProductQuerryService _productQuerryService;
        private IOrderDetailsComandService _orderDetailsComandService;
        private IOrderDetailsQuerryService _orderDetailsQuerryService;
        private IOrderComandService _orderComandService;
        private IOrderQuerryService _orderQuerryService;


        public ViewCustomer()
        {
           
            _productComandService = ProductComandServiceSingleton.Instance;
            _productQuerryService = ProductQuerryServiceSingleton.Instance;
            _orderDetailsComandService = OrderDetailComandServiceSingleton.Instance;
            _orderDetailsQuerryService = OrderDetailQuerryServiceSingleton.Instance;
            _orderComandService = OrderComandServiceSingleton.Instance;
            _orderQuerryService = OrderQuerryServiceSingleton.Instance;
            _basket= new Cos();
            _order = new CreateOrderRequest();
            
            _customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 77771212);

        }
        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa lista de produse.");
            Console.WriteLine("Apasati tasta 2 pentru a adauga produse in cos");
            Console.WriteLine("Apasati tasta 3 pentru a sterge produse din cos.");
            Console.WriteLine("Apasati tasta 4 pentru a modifica produse din cos.");
            Console.WriteLine("Apasati tasta 5 pentru a afisa cosul de cumparaturi.");
            Console.WriteLine("Apasati tasta 6 pentru a trimite comanda.");
            Console.WriteLine("Apasati tasta 7 pentru a anula o comanda.");
            Console.WriteLine("Apasati tasta 8 pentru a afisa detalii despre comanda.");


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
                        AddProductsInBasket();
                        break;
                    case 3:
                        RemoveProductsFromBasket();
                        break;
                    case 4:
                        UpdateBasket();
                        break;
                     case 5:
                        Console.WriteLine(this._basket);
                        break;
                    case 6:
                        SendOrder();
                        break;
                    case 7:
                        CancelOrder();
                        break;
                    case 8:
                        ShowOrderDetails();
                        break;
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }
        public void ShowProducts()
        {
            _productQuerryService.ShowProducts();
        }     
        public void AddProductsInBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Console.WriteLine("Introduceti cantitatea dorita.");
            int qty = 0;
            qty = Int32.Parse(Console.ReadLine());



            Product product = _productQuerryService.FindProductByName(productName);
            if (product != null)
            {
                ProductDto productDto = new ProductDto(product, qty);
                this._basket.AddProduct(productDto);
                Console.WriteLine("Produsul  a fost adaugat cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }
        }
        public void RemoveProductsFromBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Product product = _productQuerryService.FindProductByName(productName);
            if (product != null)
            {

                this._basket.RemoveProductByName(productName);
                Console.WriteLine("Produsul  a fost sters cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }
        }
        public void UpdateBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Console.WriteLine("Introduceti cantitatea dorita.");
            int qty = 0;
            qty = Int32.Parse(Console.ReadLine());



            Product product = _productQuerryService.FindProductByName(productName);
            if (product != null)
            {
                ProductDto productDto = new ProductDto(product, qty);
                this._basket.UpdateBasket(productDto, qty);
                Console.WriteLine("Produsul  a fost modificat cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }
        }
        public void SendOrder()
        {
            
            CreateOrderRequest request = this._basket.createOrder(_customer);
            if (request.order.GetAmmount() != 0)
            {
                _orderComandService.AddOrder(request.order);
                request.Details.ForEach(x =>
                {

                    _orderDetailsComandService.AddOrderDetails(x);
                });
                request.order.SetOrderStatus("Done");
                _orderDetailsComandService.SaveOrderDetails();
                _orderComandService.SaveOrder();
                _productComandService.SaveProduct();

                _orderQuerryService.ReadOrder();
                _orderDetailsQuerryService.ReadOrderDetails();
                _productQuerryService.ReadProduct();

                

                Console.WriteLine("Comanda cu ID-ul: " + request.order.GetOrderID() + " a fost trimisa.");
            }
            else
                Console.WriteLine("Nu puteti trimite o comanda goala.");
        }
        public void CancelOrder()
        {
            Console.WriteLine("Introduceti ID-ul comenzii");
            String orderID = "";
            orderID = Console.ReadLine();
           
                if (_orderQuerryService.CancelOrder(_customer, orderID) == true)
                    Console.WriteLine("Comanda cu ID-ul: " + orderID + " a fost anulata cu succes!");
                else
                    Console.WriteLine("Nu puteti anula o comanda inexistenta/care nu va apartine.");
            
            
            List<OrderDetails> orderDetails = _orderDetailsQuerryService.GetOrderDetailsByOrderID(orderID);
            _productQuerryService.UpdateStock(orderDetails);



            _productComandService.SaveProduct();
            _orderComandService.SaveOrder();
            _orderQuerryService.ReadOrder();            
            _productQuerryService.ReadProduct();


        }
        public void ShowOrderDetails()
        {

            Console.WriteLine("Introduceti ID-ul comenzii");
            String orderID = "";
            orderID = Console.ReadLine();
            //List<OrderDetails> orderDetails = _serviceOrderDetails.GetOrderDetailsByOrderID(orderID);
            _orderDetailsQuerryService.ShowOrderDetails2(orderID);

        }

    }
}
