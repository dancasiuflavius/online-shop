using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Model
{
    public interface ISorting
    {
        List<Product> AscendingSortByPrice(List<Product> _productList);
        List<Product> DescendingSortByPrice(List<Product> _productList);
        List<Product> SortDate(List<Product> list);
    }
}
