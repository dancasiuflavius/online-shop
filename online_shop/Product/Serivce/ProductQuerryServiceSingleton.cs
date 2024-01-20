using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Serivce
{
    public class ProductQuerryServiceSingleton
    {
        private static readonly IProductQuerryService _instance = new ProductQuerryService();

        public static IProductQuerryService Instance => _instance;

        private ProductQuerryServiceSingleton() { }
    }
}
