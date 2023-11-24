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
    public class ViewCos
    {

        private ServiceUser _serviceUser;
        private ServiceOrders _serviceOrders;
        private ServiceProducts _serviceProducts;
        private ServiceOrderDetails _serviceOrderDetails;
        private Cos _cos;
        public ViewCos()
        {
            _serviceUser = new ServiceUser();
            _serviceOrders = new ServiceOrders();
            _serviceProducts = new ServiceProducts();
            _serviceOrderDetails = new ServiceOrderDetails();
            _cos = new Cos();
        }
        public void Meniu()
        {

            Console.WriteLine("Apasati tasta 1 pentru a afisa produsele din cos");
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
                        _cos.ShowBasketProducts();
                        break;
                    case 2:

                    case 3:

                    case 4:

                    case 5:

                        break;
                    default:

                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }

    }
}



