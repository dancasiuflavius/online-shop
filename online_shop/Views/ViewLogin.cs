using online_shop.Orders.Service;
using online_shop.Products.Model;
using online_shop.Products.Serivce;
using online_shop.Users.Models;
using online_shop.Users.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Views
{
    public class ViewLogin
    {
        private IUserComandService _userComandService;
        private IUserQuerryService _userQuerryService;

        public ViewLogin()
        {
            _userComandService = UserComandServiceSingleton.Instance;
            _userQuerryService = UserQuerryServiceSingleton.Instance;
        }
        public void LoginFunction()
        {

            string email = "";
            string parola = "";
            Console.WriteLine("Introduceti email-ul: ");
            email = Console.ReadLine();
            Console.WriteLine("Introduceti parola: ");
            parola = Console.ReadLine();


            User user = _userQuerryService.findUserByEmailAndPassword(email, parola); 
            
            String rol = "";
            
            rol = user.GetType();

            if (rol.Equals("admin"))
            {
                ViewAdmin admin = new ViewAdmin();
                admin.Play();
            }
            else if (rol.Equals("customer"))
            {
                ViewCustomer customer = new ViewCustomer();
                customer.Play();
            }
            

        }
        public void Play()
        {
            bool running = true;

            int alegere = 0;

            while (running)
            {

                LoginFunction();

            }
        }
    }
}
