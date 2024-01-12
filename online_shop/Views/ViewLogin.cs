using online_shop.Models;
using online_shop.Products.Serivce;
using online_shop.Services;
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
        protected ServiceUser _serviceUser;



        public ViewLogin()
        {
            _serviceUser = new ServiceUser();
           
        }









        //User customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 77771212);
        public void LoginFunction()
        {
            
            string email = "";
            string parola = "";
            Console.WriteLine("Introduceti email-ul: ");
            email = Console.ReadLine();
            Console.WriteLine("Introduceti parola: ");
            parola = Console.ReadLine();            
            

            User user = new User();
            user=_serviceUser.findUserByEmailAndPassword(email, parola);
            String rol = "";
            rol = user.GetType();

            if (rol.Equals("admin"))
            {
                ViewAdmin admin = new ViewAdmin();
                admin.Play();
            }
            else if(rol.Equals("customer"))
            {
                ViewCustomer customer = new ViewCustomer();
                customer.Play();
            }
                

        }
        //public void LoginAdmin()
        //{
        //    ViewAdmin admin = new ViewAdmin();
        //    admin.Play();
        //}
        //public void LoginUser()
        //{
        //    ViewUser admin = new ViewUser();
        //        admin.Play();
        //}
    
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
