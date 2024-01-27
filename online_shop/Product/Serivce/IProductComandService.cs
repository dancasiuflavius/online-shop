using online_shop.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Products.Model
{
    public interface IProductComandService
    {
        bool AddProduct(Product product);
        bool RemoveProduct(string id);
        bool UpdateProduct(string id, string name, int price, string description, DateTime createDate, int stock, string newId);
        void SaveProduct();
      
    }
}
