using online_shop.DTO;
using online_shop.Models;
using online_shop.Products.Model;
using online_shop.Services;
using online_shop.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewCustomer : ViewUser
    {



        private Cos _cos;
        private Customer customer;

        public ViewCustomer()
        {

            _cos = new Cos();
            customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 077771212);
        }



        public void Meniu()
        {
            base.Meniu();
            Console.WriteLine("Apasati tasta 5 pentru a adauga produse in cos");
            Console.WriteLine("Apasati tasta 6 pentru a sterge produse din cos.");
            Console.WriteLine("Apasati tasta 7 pentru a modifica produse din cos.");
            Console.WriteLine("Apasati tasta 8 pentru a afisa cosul de cumparaturi.");
            Console.WriteLine("Apasati tasta 9 pentru a trimite comanda.");
            Console.WriteLine("Apasati tasta 10 pentru a anula o comanda.");
            Console.WriteLine("Apasati tasta 11 pentru a afisa detalii despre comanda.");



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
                        RemoveProductFromBasket();
                        break;
                    case 7:
                        UpdateBasket();
                        break;
                    case 8:
                        Console.WriteLine(this._cos);
                        break;
                    case 9:
                        SendOrder();
                        break;
                    case 10:
                        CancelOrder();
                        break;
                    case 11:
                        ShowOrderDetails();
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
            if (product != null)
            {
                ProductDto productDto = new ProductDto(product, qty);
                this._cos.AddProduct(productDto);
                Console.WriteLine("Produsul  a fost adaugat cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }
        }
        public void RemoveProductFromBasket()
        {
            Console.WriteLine("Introduceti numele produsului.");
            string productName = "";
            productName = Console.ReadLine();
            Product product = _serviceProducts.FindProductByName(productName);
            if (product != null)
            {

                this._cos.RemoveProductByName(productName);
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



            Product product = _serviceProducts.FindProductByName(productName);
            if (product != null)
            {
                ProductDto productDto = new ProductDto(product, qty);
                this._cos.UpdateBasket(productDto, qty);
                Console.WriteLine("Produsul  a fost modificat cu succes");
            }
            else
            {
                Console.WriteLine("Nu exista...................");

            }
        }
        public void SendOrder()
        {
            CreateOrderRequest request = this._cos.createOrder(_serviceOrders, _serviceOrderDetails, _serviceProducts,customer);
            _serviceOrders.AddOrder(request.order);
            request.Details.ForEach(x =>
            {

                _serviceOrderDetails.AddOrderDetails(x);
            });
            request.order.SetOrderStatus("done");
            _serviceOrderDetails.SaveOrderDetails();
            _serviceOrders.SaveOrder();
            _serviceProducts.SaveProduct();

            Console.WriteLine("Comanda cu ID-ul: " + request.order.GetOrderID() +" a fost trimisa.");
        }
        public void CancelOrder()
        {
            Console.WriteLine("Introduceti ID-ul comenzii");
            String orderID = "";
            orderID = Console.ReadLine();
            if (_serviceOrders.CancelOrder(customer, orderID) == true)
                Console.WriteLine("Comanda cu ID-ul: " + orderID + " a fost anulata cu succes!");
            else
                Console.WriteLine("Nu puteti anula o comanda inexistenta/care nu va apartine.");
            List<OrderDetails> orderDetails = _serviceOrderDetails.GetOrderDetailsByOrderID(orderID);
            _serviceProducts.UpdateStock(orderDetails);



            _serviceProducts.SaveProduct();
            _serviceOrders.SaveOrder(); 
         
          
        }
        public void ShowOrderDetails()
        {

            Console.WriteLine("Introduceti ID-ul comenzii");
            String orderID = "";
            orderID = Console.ReadLine();
            //List<OrderDetails> orderDetails = _serviceOrderDetails.GetOrderDetailsByOrderID(orderID);
            _serviceOrderDetails.ShowOrderDetails2(orderID);
            
        }



    }
}
