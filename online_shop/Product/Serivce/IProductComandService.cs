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
        void AddProduct(Product product);
        void RemoveProduct(string id);
        void UpdateProduct(string id, string name, int price, string description, DateTime createDate, int stock, string newId);
        void SaveProduct();
      
    }
}
