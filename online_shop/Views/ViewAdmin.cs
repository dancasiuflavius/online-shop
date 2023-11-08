using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Services;

namespace online_shop.Views
{
    public class ViewAdmin
    {
        private ServiceCustomer _serviceCustomer;
        private ServiceOrders _serviceOrders;
        private ServiceProducts _serviceProducts;

        public ViewAdmin()
        {
            _serviceCustomer = new ServiceCustomer();
            _serviceOrders = new ServiceOrders();
            _serviceProducts = new ServiceProducts();
        }
        public void AddProduct()
        {

        }
        public void RemoveProduct()
        {
            String id = "";
            Console.WriteLine("Introduceti ID-ul produsului: ");
            id = Console.ReadLine();
            if (this._serviceProducts.RemoveProduct(id) == true)
                Console.WriteLine("Produs eliminat cu succes!");
            else
                Console.WriteLine("Nu puteti elimina un produs inexistent.");
        }
        public void UpdateProduct()
        {

            try
            {
                String ID = "";
                String _name = "";
                int _price = 0;
                String _description = "";
                DateTime _createDate;
                int _stock = 0;
                String _newID = "";

                Console.WriteLine("Introduceti ID-ul produsului: ");
                ID = Console.ReadLine();

                Console.WriteLine("Introduceti numele nou al produsului: ");
                _name = Console.ReadLine();

                Console.WriteLine("Introduceti pretul nou al produsului: ");
                _price = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti o noua descriere aprodusului: ");
                _description = Console.ReadLine();

                Console.WriteLine("Introduceti o noua data de fabricatie a produsului");
                _createDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti cantitatea noua existenta a produsului: ");
                _stock = Int32.Parse(Console.ReadLine());
         
                Console.WriteLine("Introduceti ID-ul nou al produsului: ");
                _newID = Console.ReadLine();

                

                this._serviceProducts.UpdateProduct(ID, _name, _price, _description, _createDate, _stock, _newID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }

        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a adauga un produs.");
            Console.WriteLine("Apasati tasta 2 pentru a elimina un produs.");
            Console.WriteLine("Apasati tasta 3 pentru a modifica datele unui produs.");
            
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
                        break;
                    case 2:
                       

                        break;
                    case 3:
                        

                        break;
                    case 4:
                        

                        break;

                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }


    }
}
