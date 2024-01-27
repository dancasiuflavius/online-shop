using online_shop.Models;
using online_shop.Users.Models;
using online_shop.Users.Service;

namespace online_shop.Views
{
    public class ViewLogin
    {
        private IUserComandService _userComandService;
        private IUserQuerryService _userQuerryService;
        //private Customer _customer;
        //private Admin admin;


        public ViewLogin()
        {
            _userComandService = UserComandServiceSingleton.Instance;
            _userQuerryService = UserQuerryServiceSingleton.Instance;
            //_customer = new Customer("customer", 1, "customer1@mail", "123", "Flavius", "Sibiu Cisnadie Str Cetatii 46", 77771212);
            //admin = new Admin("admin", 444, "admin@mail", "qwer1324", "lowest permission");
        }
        public void LoginFunction()
        {

            string email = "";
            string parola = "";
            Console.WriteLine("Introduceti email-ul: ");
            email = Console.ReadLine();
            Console.WriteLine("Introduceti parola: ");
            parola = Console.ReadLine();


            User user = new User();
            user =_userQuerryService.findUserByEmailAndPassword(email, parola); 
            
            String rol = "";
            if (user != null)
            {
                rol = user.GetType();

                if (rol.Equals("admin"))
                {
                    
                    ViewAdmin admin = new ViewAdmin(user as Admin);
                    admin.Play();
                }
                else if (rol.Equals("customer"))
                {
                    
                    ViewCustomer customer = new ViewCustomer(user as Customer);
                    customer.Play();
                }
            }
            else
                Console.WriteLine("Utilizator inexistent.");
                
            
           
           
            

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
