using online_shop.Models;
using online_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Common
{
    public class Cos
    {
        List<Product> _produseCos ;

        public Cos()
        {
            _produseCos = new List<Product>();
        }
        public Cos(List<Product> produseCos)
        {
            _produseCos = produseCos;

        }
        public void AddProductInBasket(Product product)
        {
            _produseCos.Add(product);
        }
        
        public void ShowBasketProducts()
        {
            
            for (int i = 0; i < _produseCos.Count; i++)
            {
                if (_produseCos[i] != null)
                Console.WriteLine(_produseCos[i].GetProductDescription());
            }
                    
            
        }
    }
}
