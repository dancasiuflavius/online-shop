using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Serivce
{
    public class ProductComandServiceSingleton
    {
        private static readonly IProductComandService _instance = new ProductComandService();

        public static IProductComandService Instance => _instance;

        private ProductComandServiceSingleton() { }

    }
}
